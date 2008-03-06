using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace pi_counter_ui {
    public class PiLibrary {

        public delegate void listener(int idxInTable, int idxInPi);

		[DllImport("pi-counter.dll", CharSet = CharSet.Auto)]
        public static extern int findNumber1(string number);

		[DllImport("pi-counter.dll", CharSet = CharSet.Auto)]
        unsafe static extern void findNumbersFT(char * from, char * to, int * outTable, listener listnr);

		[DllImport("pi-counter.dll", CharSet = CharSet.Auto)]
		unsafe static extern void findNumbers2(string[] numbers, int count, int* outTable, listener listnr);

        public static void findNumbersFTManaged(string from, string to, int[] outTable, listener listnr) {
            unsafe {
                fixed (int* table = outTable) {
                    fixed (char* fr = from, t=to) {
                        //GCHandle gcHandle = GCHandle.Alloc(listnr, GCHandleType.Pinned);
                        System.Console.Out.WriteLine("begin findNumbersFT c#");
                        findNumbersFT(fr, t, table, listnr);
                        System.Console.Out.WriteLine("end findNumbersFT c#");
                        //gcHandle.Free();
                    }
                }
            }
        }

        public static void findNumbers2Managed(string[] numbers, int[] outTable, listener listnr) {
            if (numbers == null || outTable == null || numbers.Length != outTable.Length) {
                throw new ArgumentException("nie zgadzaja sie dlugosci lub sa nulle");
            }
            unsafe {
                //TODO RS: tu sa jakies machinacje z gc.. 
                fixed (int* table = outTable) {
                    //fixed (string ** numb = numbers) {
                        //GCHandle gcHandle = GCHandle.Alloc(table, GCHandleType.Pinned);
                        System.Console.Out.WriteLine("begin findNumbers2 c#");
                        findNumbers2(numbers, numbers.Length, table, null);
                        System.Console.Out.WriteLine("end findNumbers2 c#");
                        //gcHandle.Free();
                    //}
                }
            }
        }

    }
}
