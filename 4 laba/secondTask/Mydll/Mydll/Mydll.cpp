// Mydll.cpp : Определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"

#include < stdio.h >  

extern "C" {
	__declspec(dllexport) int add(int a, int b) {
		return a + b;
	}
	__declspec(dllexport) int subtract(int a, int b) {
		return a - b;
	}
}


