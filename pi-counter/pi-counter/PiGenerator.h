#pragma once
#include <string>
#include "gmp.h"

using namespace std;

//return value indicates whether to stop calculation
typedef bool (__stdcall *CoolListener) (int timePercentComplete, int lengthPercentComplete);
typedef void (__stdcall *Listener) ();
typedef bool (__stdcall *BoolListener) ();

extern "C" __declspec(dllexport) void generatePi(wchar_t *fileName, int digits, int maxTimeMs, CoolListener listener);
extern "C" __declspec(dllexport) void CalculateFunction(CoolListener listener, wchar_t *piFileName, wchar_t *resultFileName, char *a, char *b, int maxTimeMs, unsigned int numberOfDigitsToCheck, unsigned __int64 *numberOfFound, unsigned int *digitsChecked);

bool saveState(int d, int alg, int count, int prec);
int readState(int *d, int *alg, int *count, int *prec);
bool savePi(char* filename);
bool saveMpf(mpf_t var, const char * filename);
bool readMpf(mpf_t var, const char *filename);
