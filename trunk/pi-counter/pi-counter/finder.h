


typedef void ( *LISTENER) (long, long);

 __declspec(dllexport) long findNumber1(char * number);
__declspec(dllexport) void findNumbersFT(char * from, char * to,long  out [], LISTENER listener);
__declspec(dllexport) void findNumbers2(char * numbers [],int count,long  out [],LISTENER listener);