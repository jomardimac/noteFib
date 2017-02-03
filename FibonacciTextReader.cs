//Name: Jomar Dimaculangan
//ID:   1142239


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;


namespace dimaculangan_hw3 {
    class FibonacciTextReader : System.IO.TextReader{
        //fields:
        public int fibLines;
        public BigInteger num;
        BigInteger prev2 = 0;
        BigInteger prev1 = 1;

        //constructor to have max lines:
        public FibonacciTextReader(int maxLines) {
            fibLines = maxLines;
            num = 0;
        }

        public override string ReadLine() {
            //go through the whole list
            BigInteger temp;
            //base case: if maxLine = 0, return 0;
            //           if maxLine = 1, return 1;
            //if not 0 or 1, add [lines - 1] + [lines - 2]
            
            //0,1,1,2,3,5,7, add temp1 and temp2 and return that
            if (num == 0) {
                num++;
                return "0";
            }
            else if (num == 1) {
                num++;
                return "1";
            }
            //need to add previous one + previous two together and iterate
            else {
                while (num < fibLines) {
                    temp = prev2 + prev1;
                    prev2 = prev1;
                    prev1 = temp;
                    num++;
                    return prev1.ToString();
                }
            }
            return null;
        }
        
        //concatinates lines together, will be called repeatedly.
        public override string ReadToEnd() {
            //stringbuilder according to msdn is a class that can build out of multiple strings
            StringBuilder txt = new StringBuilder();
            num = 0;
            //iterate through the array until maxlines are done:
            for (int i = 0; i < fibLines; i++) {
                //formatting requirement
                string temp = (i+1).ToString();
                txt.Append(temp + ": ");
                txt.Append(ReadLine());
                txt.AppendLine();
                
            }
            //return the whole strinbuilder class to a string. will be using loadtext();
            return txt.ToString();
        }

    }
}
