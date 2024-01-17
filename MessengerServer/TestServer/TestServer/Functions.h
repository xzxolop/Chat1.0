#pragma once
#include <vector>
#include <iostream>

/*
������� ������ ������� char
*/
inline void Print(const std::vector<char>& v) {
	for (auto x : v) {
		std::cout << x;
	}
	std::cout << std::endl;
}

/*
������� �������� ��������� �������
message - ������ char, � ���������� ����� ";;;5", ��� ��������� ����� ���������� �������.
clients - ������ �������, ������� ����� ���������� ���������.
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
������� �������� ��������� �� ��������.
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