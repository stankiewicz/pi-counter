#pragma once
#include <string>
#include "gmp.h"

using namespace std;

//return value indicates whether to stop calculation
typedef bool (__stdcall *CoolListener) (int timePercentComplete, int lengthPercentComplete);
typedef void (__stdcall *Listener) ();
typedef bool (__stdcall *BoolListener) ();

extern "C" __declspec(dllexport) void generatePi(int digits, CoolListener listener);
extern "C" __declspec(dllexport) void CalculateFunction(wchar_t *filename, char *a, char *b, int maxTimeMs, unsigned int numberOfDigitsToCheck, CoolListener listener);

bool saveState(int d, int alg, int count, int prec);
int readState(int *d, int *alg, int *count, int *prec);
bool savePi(char* filename);
bool saveMpf(mpf_t var, const char * filename);
bool readMpf(mpf_t var, const char *filename);
