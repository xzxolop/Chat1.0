#pragma once
#include <WinSock2.h>
#include <WS2tcpip.h>

#include <vector>
#include <iostream>

/*
Функция печати вектора char
*/
inline void Print(const std::vector<char>& v) {
	for (auto x : v) {
		std::cout << x;
	}
	std::cout << std::endl;
}

/*
Функция отправки сообщения клиенту
message - вектор char, с концевиком ввиде ";;;5", это сообщение будет отправлено клиенту.
clients - вектор сокетов, которым будет отправлено сообщение.
*/
inline void SendMes(const SOCKET& client, std::vector<char>& message) {
	int erCode = send(client, message.data(), 1024, 0);
	if (erCode == SOCKET_ERROR) {
		std::cout << "Failed to send message" << std::endl;
	}
	else
	{
		std::cout << "Message send" << std::endl;
	}
}

/*
Функция принятия сообщений от клиента.
*/
inline void RecvMes(const SOCKET& client, std::vector<char>& message) {
	int erCode = recv(client, message.data(), 1024, 0);
	if (erCode == INVALID_SOCKET) {
		std::cout << "Failed to recv message";
	}
	else {
		std::cout << message.data() << std::endl;
	}
}

inline void RecvAndSend(std::vector<SOCKET>& Clients, int ID) {
	char* buffer = new char[1024];
	for (;; Sleep(75)) { // здесь цикл не случаен.
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

inline void RecvAndSend2(std::vector<SOCKET>& Clients, int ID) {
	auto message = new std::vector<char>(1024);
	while (true) {
		memset(message->data(), 0, sizeof(message->data()));
		if (recv(Clients[ID], message->data(), 1024, 0)) {
			Print(*message);
			for (int i = 0; i < Clients.size(); i++) {
				send(Clients[i], message->data(), 1024, 0);
			}
		}
	}
	delete[] message;
}