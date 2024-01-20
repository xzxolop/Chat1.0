#include <WinSock2.h> // заголовочный файл, для работы с сокетами.
#include <WS2tcpip.h> // заголовочный файл, для работы с TCP/IP

#include <thread>

#include "Functions.h"
#include "Socket.h"

#pragma comment(lib, "ws2_32.lib") // прилинковывает к приложению динамическую библиотеку ядра ОС

int main() {
	MySocket Socket;
	Socket.InitSocketInterfaces(2, 2);
	Socket.CreateSocket("127.0.0.1", 1234);
	Socket.Listen(SOMAXCONN);

	std::vector<SOCKET> Clients;
	std::string WelcomeMes{"Hello!\n"};
	while (true)
	{
		SOCKET Client = Socket.Accept();
		Clients.push_back(Client);

		std::thread th(RecvAndSend, std::ref(Clients), Clients.size() - 1);
		th.detach();
		
		SendMes(Clients, "Server: Hello\n;;;5");
	}
	
	return 0;
}