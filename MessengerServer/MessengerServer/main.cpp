#pragma comment(lib,"ws2_32.lib")
#include <WinSock2.h>
#include <iostream>
#include <WS2tcpip.h>

SOCKET Connect;
SOCKET* Connections;
SOCKET Listen;

int ClientCount = 0;

void SendMessageToClient(int ID) {
	char* buffer = new char[1024];
	for (;; Sleep(75)) {
		memset(buffer, 0, sizeof(buffer));
		if (recv(Connections[ID], buffer, 1024, NULL)) {
			std::cout << buffer << std::endl;
			for (int i = 0; i <= ClientCount; i++) {
				send(Connections[i], buffer, strlen(buffer), NULL); //отправка сообщени€ о подключении всем пользовател€м
			}
		}
	}
	delete buffer;
}

int main() {
	setlocale(LC_ALL, "rus");
	WSAData data;
	WORD version = MAKEWORD(2, 2);
	//инициализаци€ сокетов
	int res = WSAStartup(version, &data);
	if (res != 0) {
		return 0;
	}

	struct addrinfo hints;
	struct addrinfo* result;

	Connections = (SOCKET*)calloc(64, sizeof(SOCKET));

	ZeroMemory(&hints, sizeof(hints));
	//настраиваем сокет
	hints.ai_family = AF_INET;
	hints.ai_flags = AI_PASSIVE;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;

	getaddrinfo(nullptr, "7770", &hints, &result);

	// инициализаци€ сокета, объ€вление сервера в локальной сети	
	Listen = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
	bind(Listen, result->ai_addr, result->ai_addrlen);
	listen(Listen, SOMAXCONN);
	
	freeaddrinfo(result);

	std::cout << "Start server.." << std::endl;
	char m_connect[] = "Connect.."; // то что видит клиент при подключении
	
	//ќбработка клиентов
	for (;; Sleep(75)) {
		
		if (Connect = accept(Listen, nullptr, nullptr)) {
			std::cout << "Client connect..." << std::endl;
			Connections[ClientCount] = Connect;
			send(Connections[ClientCount], m_connect, strlen(m_connect),NULL);
			ClientCount++;

			CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)SendMessageToClient,(LPVOID)(ClientCount - 1), NULL, NULL);
								
		}

	}
	
	return 1;
}