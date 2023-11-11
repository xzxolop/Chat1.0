#pragma comment(lib, "Ws2_32.lib")
#include <WinSock2.h>
#include <iostream>
#include <WS2tcpip.h>

SOCKET Connect;
SOCKET* Connections;
SOCKET Listen;


int main() {
	setlocale(LC_ALL, "rus");
	WSAData data;
	WORD version = MAKEWORD(2, 2);
	int res = WSAStartup(version, &data);
	if (res != 0) {
		return 0;
	}

	struct addrinfo hints;
	struct addrinfo* result;

	Connections = (SOCKET*)calloc(64, sizeof(SOCKET));

	ZeroMemory(&hints, sizeof(hints));

	hints.ai_family = AF_INET;
	hints.ai_flags = AI_PASSIVE;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;

	getaddrinfo(nullptr, "7770", &hints, &result);

	// след. 2 строчки - объ€вление сервера в локальной сети	
	Listen = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
	bind(Listen, result->ai_addr, result->ai_addrlen);
	
	
	listen(Listen, SOMAXCONN);
	freeaddrinfo(result);

	std::cout << "Start server.." << std::endl;
	char m_connect[] = "Connect..";
	for (;; Sleep(75)) {

	}
	

}