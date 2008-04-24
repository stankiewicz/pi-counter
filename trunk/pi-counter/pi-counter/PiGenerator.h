#pragma once
#include <string>
#include "gmp.h"

using namespace std;

//return value indicates whether to stop calculation
//typedef bool (__stdcall *Listener) (float percentComplete);
typedef void (*Listener) ();
typedef bool (*BoolListener) ();

extern "C" __declspec(dllexport) void generatePi(int digits, Listener listener);
extern "C" __declspec(dllexport) void CalculateFunction(wchar_t *filename, char *a, char *b, int maxTimeMs, unsigned int numberOfDigitsToCheck, BoolListener listener);

void generateNewPi(int d, int alg, Listener listener);
bool saveState(int d, int alg, int count, int prec);
int readState(int *d, int *alg, int *count, int *prec);
bool savePi(char* filename);
bool saveMpf(mpf_t var, const char * filename);
bool readMpf(mpf_t var, const char *filename);
