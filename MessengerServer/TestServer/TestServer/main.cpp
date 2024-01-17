#include <WinSock2.h> // заголовочный файл, для работы с сокетами.
#include <WS2tcpip.h> // заголовочный файл, для работы с TCP/IP

#include <thread>

#include "Functions.h"
#include "Socket.h"

#pragma comment(lib, "ws2_32.lib") // прилинковывает к приложению динамическую библиотеку ядра ОС

std::vector<char> buf(1024);






int main() {
	std::vector<SOCKET> Clients;

	Server serv;
	serv.InitSocketInterfaces(2, 2);
	serv.CreateSocket("127.0.0.1", 1234);
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

			//SendMessageParams params{ Clients, Clients.size() - 1 };
			//CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)SendMessageToClient, (LPVOID)(&Clients, Clients.size()-1) , NULL, NULL);
			std::thread th(RecvAndSend, std::ref(Clients), Clients.size()-1);
			th.detach();
			Sleep(1000);
			std::string mes("Server: Hello;;;5");
			std::vector<char> message{mes.begin(), mes.end()};
			SendMes(Clients, message);
		}

	}
	
	return 0;
}