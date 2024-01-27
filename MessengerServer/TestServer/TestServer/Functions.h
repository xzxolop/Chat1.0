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

inline int RecvMes(const SOCKET& client, char* message) {
	int size = recv(client, message, 1024, 0);
	if (size == SOCKET_ERROR) {
		std::cout << "Failed to recv message" << std::endl;
	}
	else {
		message[size] = '\0';
		std::cout << message;
	}
	
	return size;
}

inline void SendMes(const SOCKET& client, char* message) {
	int erCode = send(client, message, 1024, 0);
	if (erCode == SOCKET_ERROR) {
		std::cout << "Failed to send message" << std::endl;
	}
}

inline void RecvAndSend(std::vector<SOCKET>& Clients, int ID) {
	auto message = new std::vector<char>(1024);
	while (true) {
		if (RecvMes(Clients[ID], message->data())) {
			for (int i = 0; i < Clients.size(); i++) {
				SendMes(Clients[i], message->data());
			}
		}
	}
	delete[] message;
}

namespace OldFunctions {
	inline void RecvAndSend_old(std::vector<SOCKET>& Clients, int ID) {
		auto message = new std::vector<char>(1024);
		while (true) {
			if (int size = recv(Clients[ID], message->data(), 1024, 0)) { // if нужен, чтобы не было "спаминга" сообщениями.
				message->data()[size] = '\0';
				std::cout << message->data();

				for (int i = 0; i < Clients.size(); i++) {
					send(Clients[i], message->data(), 1024, 0);
				}
			}
		}
		delete[] message;
	}
}