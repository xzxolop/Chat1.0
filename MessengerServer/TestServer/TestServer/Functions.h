#pragma once
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
inline void SendMess(const std::vector<SOCKET>& clients, const std::vector<char>& message) {
	for (auto i = 0; i < clients.size(); i++) {
		int erCode = send(clients[i], message.data(), message.size(), 0);
		if (erCode == SOCKET_ERROR) {
			std::cout << "Failed to send message" << std::endl;
		}
		else
		{
			std::cout << "Message send" << std::endl;
		}
	}
}

/*
Функция принятия сообщений от клиентов.
*/
inline void RecvMes(const std::vector<SOCKET>& clients, std::vector<char>& message) {
	for (auto i = 0; i < clients.size(); i++) {
		int erCode = recv(clients[i], message.data(), message.size(), 0);
		if (erCode == INVALID_SOCKET) {
			std::cout << "Failed to recv message";
		}
		else {
			Print(message);
		}
	}
}