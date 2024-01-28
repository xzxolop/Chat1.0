#pragma once
#include <WinSock2.h>
#include <WS2tcpip.h>

#include <vector>
#include <iostream>
#include <thread>

template<typename T>
void Print(const std::vector<T>& v) {
	for (auto x : v) {
		std::cout << x;
	}
	std::cout << std::endl;
}

inline bool IsClientCommand(const char* message, const char* command) {
	auto index = strstr(message, command);
	if (index != nullptr) {
		return true;
	}
	else {
		return false;
	}
}


inline int RecvMes(std::vector<SOCKET>& Clients, int id, char* message) {
	int size = recv(Clients[id], message, 1024, 0);
	if (size == SOCKET_ERROR) {
		std::cout << "Failed to recv message" << std::endl;
		closesocket(Clients[id]);
	}
	else {
		message[size] = '\0';
		std::cout << message;
	}
	
	if (IsClientCommand(message, "/disconnect")) {
		std::cout << "Client disconnect" << std::endl;
		closesocket(Clients[id]);
		shutdown(Clients[id], SD_BOTH);
		Clients.erase(Clients.begin() + id);
		return 0;
	}
	
	return size;
}

inline void SendMes(const SOCKET& client, char* message) {
	int erCode = send(client, message, 1024, 0);
	if (erCode == SOCKET_ERROR) {
		std::cout << "Failed to send message" << std::endl;
	}
}

inline void RecvAndSend(std::vector<SOCKET>& Clients, int id) {
	auto message = new std::vector<char>(1024); // буфер надо чистить
	while (true) {
		if (RecvMes(Clients, id, message->data())) {
			for (int i = 0; i < Clients.size(); i++) {
				SendMes(Clients[i], message->data());
			}
		}
		else {
			return;
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

