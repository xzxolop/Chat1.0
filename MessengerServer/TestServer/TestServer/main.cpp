#include <WinSock2.h> // заголовочный файл, для работы с сокетами.
#include <WS2tcpip.h> // заголовочный файл, для работы с TCP/IP

#include <thread>

#include "Functions.h"

#pragma comment(lib, "ws2_32.lib") // прилинковывает к приложению динамическую библиотеку ядра ОС

std::vector<char> buf(1024);


int main() {
	WSADATA wsData; // данные о версии сокетов, с которыми мы работаем.

	// Инициализация использования библиотеки сетевых служб
	int errorCode = WSAStartup(MAKEWORD(2,2), &wsData);
	if (errorCode != 0) {
		std::cout << "Error: WinSock version initialization: " << WSAGetLastError();
		return 1;
	}
	else {
		std::cout << "WinSock initialization is OK" << std::endl;
	}

	// Инициализация сокета
	SOCKET Socket = socket(AF_INET, SOCK_STREAM, 0);
	if (Socket == INVALID_SOCKET) {
		std::cout << "Error init socket: " << WSAGetLastError() << std::endl;
		closesocket(Socket); 
		WSACleanup(); // Деинициализация использования библиотеки сетевых служб (минус счётчик ссылок).
		return 1;
	}

	// Подготовка к назначению сокета адресса ip port
	sockaddr_in servInfo;
	servInfo.sin_family = AF_INET;
	int port = 1234;
	servInfo.sin_port = htons(port); // htons переупаковывает unsigned short в байты понятные протоколу TCP/IP
	
	// Указание ip
	in_addr ip;
	char ipv4[] = "127.0.0.1";
	errorCode = inet_pton(AF_INET, ipv4, &ip);
	if (errorCode < 0) {
		std::cout << "Error in IP translation to special numeric format" << std::endl;
		return 0;
	}

	servInfo.sin_addr = ip;
	errorCode = bind(Socket, reinterpret_cast<sockaddr*>(&servInfo), sizeof(servInfo)); // Связка сокета с ip port
	if (errorCode != 0) {
		std::cout << "Error Socket binding to server info. Error # " << WSAGetLastError() << std::endl;
		closesocket(Socket);
		WSACleanup();
		return 1;
	}
	else {
		std::cout << "Socket is open on " << ipv4 << ":" << port << std::endl;
	}
	
	// Прослушивание привязанного порта для идентификации подключений
	errorCode = listen(Socket, SOMAXCONN);
	if (errorCode != 0) {
		std::cout << "Error: Can't start to listen to. Error " << WSAGetLastError() << std::endl;
		closesocket(Socket);
		WSACleanup();
		return 1;
	}
	else {
		std::cout << "Listening..." << std::endl;
	}

	// Подтверждение подключения
	std::vector<SOCKET> Clients;
	sockaddr ClientInfo;
	int client_size = sizeof(ClientInfo);

	while (true)
	{
		SOCKET Client = accept(Socket, &ClientInfo, &client_size);
		if (Client == INVALID_SOCKET) {
			std::cout << "Error: Client detected, but can't connect" << std::endl;
			closesocket(Socket);
			closesocket(Client);
			WSACleanup();
			return 1;
		}
		else {
			std::cout << "Client connected" << std::endl;
			Clients.push_back(Client);
			Sleep(1000);
			std::string mes("Server: Hello;;;5");
			std::vector<char> message{mes.begin(), mes.end()};
			SendMess(Clients, message);
		}

		RecvMes(Clients, buf); // блокирует выполнение программы до получения сообщения от клиента. Нужно создавать поток. Также нужно удалять из массива клиентиов, тех клиентиов которые отключились
		SendMess(Clients, buf);
	}
	
	return 0;
}