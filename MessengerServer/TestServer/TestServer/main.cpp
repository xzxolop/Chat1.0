#include <WinSock2.h> // заголовочный файл, для работы с сокетами.
#include <WS2tcpip.h> // заголовочный файл, для работы с TCP/IP

#include <iostream>

#pragma comment(lib, "ws2_32.lib") // прилинковывает к приложению динамическую библиотеку ядра ОС

int main() {
	WSADATA wsData; // данные о версии сокетов, с которыми мы работаем.

	// Инициализация использования библиотеки сетевых служб
	/* 
	Первый аргумент - указание диапазона версии сокета - двухбайтовая переменная типа word.
	В первом байте храниться минимальная версия сокета, во втором максимальная.
	Т.к. на данный момент актуальной является 2 версия, то используем 2,2
	Создать такую переменную можно с помощью MAKEWORD()
	Создаётся это значение по правилу y << 8 | x, при х = у = 2, MAKEWORD(2,2) = 514
	В случае успеха вернёт 0.
	*/
	int errorCode = WSAStartup(MAKEWORD(2,2), &wsData);
	if (errorCode != 0) {
		std::cout << "Error: WinSock version initialization: " << WSAGetLastError();
		return 1;
	}
	else {
		std::cout << "WinSock initialization is OK" << std::endl;
	}

	// Инициализация сокета
	/*
	AF_NET - IPv4
	SOCK_STREAM - TCP (SOCK_DGRAM - UDP)
	тип протокола 0, т.к. тип сокета и так использует протокол TCP 
	*/
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
	sockaddr ClientInfo;
	int client_size = sizeof(ClientInfo);
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
	}



	return 0;
}