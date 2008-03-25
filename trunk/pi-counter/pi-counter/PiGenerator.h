#pragma once
#include <string>
#include "gmp.h"

using namespace std;

typedef void (__stdcall *Listener) ();

extern "C" __declspec(dllexport) void __stdcall generateNewPi(int d, int alg, Listener listener);
extern "C" __declspec(dllexport) void __stdcall generatePi(int digits, Listener listener);

bool saveState(int d, int alg, int count, int prec);
int readState(int *d, int *alg, int *count, int *prec);
bool savePi(char* filename);
bool saveMpf(mpf_t var, const char * filename);
bool readMpf(mpf_t var, const char *filename);
