#include "finder.h"
#include <iostream>

using namespace std;
 
long findNumber1(char * number){
	 cout << "begin " << "findNumber1"<<endl;
	 cout << "end " << "findNumber1"<<endl;
	return 5;
}
void findNumbersFT(char * from, char * to,long  out [], LISTENER listener){
	 cout << "begin " << "findNumbersFT"<<endl;
	 cout << "from: " << from;
	 cout << "to: " << to;
	 if(out!=0){
		 int len = sizeof(out)/sizeof(long);
		for(int i =0;i<len;++i) out[i] = i;
	 }
	
	if(listener!=0)(*listener)(1,1);
	 cout << "end " << "findNumbersFT"<<endl;
}

void findNumbers2(char *numbers[], int count, long  out[], LISTENER listener){
	cout << "begin " << "findNumbers2"<<endl;
	 if(numbers!=0){
		 int len = sizeof(*numbers)/sizeof(char *);
		 cout << "numbers len " << len << endl;
		 cout << "sizeof(numbers) " << sizeof(numbers) << endl;
		 cout << "count " << count << endl;
		 for(int i =0;i<count;++i) cout << i << ": " << numbers[i] << endl;
	 }
		if(out!=0){
		 int len = sizeof(out)/sizeof(long);
		 cout << "out len " << len << endl;
		for(int i =0;i<count;++i) out[i] = i;
	 }
	if(listener!=0)(*listener)(1,1);
	cout << "end " << "findNumbers2"<<endl;
}
