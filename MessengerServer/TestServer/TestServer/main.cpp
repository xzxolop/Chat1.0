#include <WinSock2.h> // заголовочный файл, для работы с сокетами.
#include <WS2tcpip.h> // заголовочный файл, для работы с TCP/IP

#include <thread>

#include "Functions.h"
#include "Socket.h"

#pragma comment(lib, "ws2_32.lib") // прилинковывает к приложению динамическую библиотеку ядра ОС

std::vector<char> buf(1024);

std::vector<SOCKET> Clients;

void SendMessageToClient(int ID) {
	char* buffer = new char[1024];
	for (;; Sleep(75)) {
		memset(buffer, 0, sizeof(buffer));
		if (recv(Clients[ID], buffer, 1024, NULL)) {
			std::cout << buffer << std::endl;
			for (int i = 0; i < Clients.size(); i++) {
				send(Clients[i], buffer, strlen(buffer), NULL); 
			}
		}
	}
	delete buffer;
}



int main() {
	
	Server serv;
	serv.InitSocketInterfaces(2, 2);
	serv.InitSocket();
	serv.BindSocket("127.0.0.1", 1234);
	serv.Listen(SOMAXCONN);
	

	// Подтверждение подключения
	
	sockaddr ClientInfo;
	int client_size = sizeof(ClientInfo);

	while (true)
	{
		SOCKET Client = accept(serv.Socket, &ClientInfo, &client_size);
		if (Client == INVALID_SOCKET) {
			std::cout << "Error: Client detected, but can't connect" << std::endl;
			closesocket(serv.Socket);
			closesocket(Client);
			WSACleanup();
			return 1;
		}
		else {
			std::cout << "Client connected" << std::endl;
			Clients.push_back(Client);
			CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)SendMessageToClient, (LPVOID)(Clients.size() - 1), NULL, NULL);
			Sleep(1000);
			std::string mes("Server: Hello;;;5");
			std::vector<char> message{mes.begin(), mes.end()};
			SendMess(Clients, message);
		}

		//RecvMes(Clients, buf); // блокирует выполнение программы до получения сообщения от клиента. Нужно создавать поток. Также нужно удалять из массива клиентиов, тех клиентиов которые отключились
		//SendMess(Clients, buf);


	}
	
	return 0;
}