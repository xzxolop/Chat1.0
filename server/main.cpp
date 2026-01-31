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
	std::string mes {"Server: Hello;;;5"};
	std::vector<char> message{mes.begin(), mes.end()};
	while (true)
	{
		SOCKET Client = Socket.Accept();
		Clients.push_back(Client);
		SendMes(Client, message.data());

		std::thread th(RecvAndSend, std::ref(Clients), Clients.size()-1);
		th.detach();
	}
	
	return 0;
}