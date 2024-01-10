#include <WinSock2.h> // заголовочный файл, для работы с сокетами.
#include <WS2tcpip.h> // заголовочный файл, для работы с TCP/IP

#include <iostream>

#pragma comment(lib, "ws2_32.lib") // прилинковывает к приложению динамическую библиотеку ядра ОС

int main() {
	WSADATA wsData; // данные о версии сокетов, с которыми мы работаем.

	// Вызов функции запуска сокетов
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

	return 0;
}