#pragma once
#include <WinSock2.h>
#include <WS2tcpip.h>

#pragma comment(lib, "ws2_32.lib")

#include <iostream>

class ISocketServer {//Просто функционал
	
public:
	virtual void InitSocketInterfaces(int minVersion, int MaxVersion) = 0;
	
	virtual void InitSocket() = 0;

	virtual void BindSocket(const char ipv4[], int port) = 0;

	virtual void Listen(int maxClients) = 0;


	WSADATA wsData;
	SOCKET Socket;
};


class Server : public ISocketServer {
	
public:
	void InitSocketInterfaces(int minVersion, int maxVersion) override {
		int erCode = WSAStartup(MAKEWORD(minVersion, maxVersion), &wsData);
		if (erCode != 0) {
			std::cout << "Error: WinSock version initialization: " << WSAGetLastError();
			return;
		}
		else {
			std::cout << "WinSock initialization is OK" << std::endl;
		}
	}

	void InitSocket() override {
		Socket = socket(AF_INET, SOCK_STREAM, 0);
		if (Socket == INVALID_SOCKET) {
			std::cout << "Error init socket: " << WSAGetLastError() << std::endl;
			closesocket(Socket);
			WSACleanup(); // Деинициализация использования библиотеки сетевых служб (минус счётчик ссылок).
			return;
		}
	}

	void BindSocket(const char ipv4[], int port) override {
		sockaddr_in servInfo;
		servInfo.sin_family = AF_INET;
		servInfo.sin_port = htons(port); // htons переупаковывает unsigned short в байты понятные протоколу TCP/IP

		// Указание ip
		in_addr ip;
		int errorCode = inet_pton(AF_INET, ipv4, &ip);
		if (errorCode < 0) {
			std::cout << "Error in IP translation to special numeric format" << std::endl;
			return;
		}

		servInfo.sin_addr = ip;
		errorCode = bind(Socket, reinterpret_cast<sockaddr*>(&servInfo), sizeof(servInfo)); // Связка сокета с ip port
		if (errorCode != 0) {
			std::cout << "Error Socket binding to server info. Error # " << WSAGetLastError() << std::endl;
			closesocket(Socket);
			WSACleanup();
			return;
		}
		else {
			std::cout << "Socket is open on " << ipv4 << ":" << port << std::endl;
		}
	}

	// Прослушивание привязанного порта для идентификации подключений
	void Listen(int maxClients) override {
		int errorCode = listen(Socket, maxClients);
		if (errorCode != 0) {
			std::cout << "Error: Can't start to listen to. Error " << WSAGetLastError() << std::endl;
			closesocket(Socket);
			WSACleanup();
			return;
		}
		else {
			std::cout << "Listening..." << std::endl;
		}
	}
};