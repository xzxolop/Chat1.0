#pragma once
#include <WinSock2.h>
#include <WS2tcpip.h>

#pragma comment(lib, "ws2_32.lib")

#include <iostream>

class ISocket {
	
public:
	virtual void InitSocketInterfaces(int minVersion, int MaxVersion) = 0;

	virtual void CreateSocket(const char ipv4[], int port) = 0;

	virtual void Listen(int maxClients) = 0;


	WSADATA wsData;
	SOCKET Socket;
};


class MySocket : public ISocket {	
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

	void CreateSocket(const char ipv4[], int port) override {
		InitSocket();

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

	SOCKET& Accept() {
		sockaddr ClientInfo;
		int client_size = sizeof(ClientInfo);
		
		SOCKET Client = accept(Socket, &ClientInfo, &client_size);
		if (Client == INVALID_SOCKET) {
			std::cout << "Error: Client detected, but can't connect" << std::endl;
			closesocket(Socket);
			closesocket(Client);
			WSACleanup();
		}
		else {
			std::cout << "Client connected" << std::endl;
			
			return Client;
		}
	}


protected:
	void InitSocket() {
		Socket = socket(AF_INET, SOCK_STREAM, 0);
		if (Socket == INVALID_SOCKET) {
			std::cout << "Error init socket: " << WSAGetLastError() << std::endl;
			closesocket(Socket);
			WSACleanup(); // Деинициализация использования библиотеки сетевых служб (минус счётчик ссылок).
			return;
		}
	}
};