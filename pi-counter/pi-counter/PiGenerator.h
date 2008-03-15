#pragma once
#include <string>

using namespace std;

typedef void (__stdcall *Listener) ();

extern "C" __declspec(dllexport) void __stdcall generateNewPi(int d, int alg, Listener listener);
//extern "C" __declspec(dllexport) void __stdcall generatePi();

void saveState(int d, int alg, int count, int prec);
int readState(int *d, int *alg, int *count, int *prec);
void savePi(char* filename);
