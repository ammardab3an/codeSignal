using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = {"coccidiosis"};
            string[] b = {"d","ia"};
            List<string> list = findSubstrings(a,b);
        
        }
        static List<string> findSubstrings(string[] words, string[] parts){
                List<string> output = new List<string>() ;
        string test;
        int index, partLen, i, len;
        
            foreach (string word in words){
                test = word;
                partLen = 0;
                i=0;
                foreach (string part in parts){
                    len = part.Length;
                    if (len > partLen){
                        if (word.Contains(part)){
                        index = word.IndexOf(part);
                        test = word.Remove(index, part.Length).Insert(index, "[" + part + "]");
                        partLen = len;
                        i = index;
                        }
                    }
                    else if (len == partLen){
                        if (word.Contains(part)){
                            index = word.IndexOf(part);
                            if (index < i){
                                test = word.Remove(index, part.Length).Insert(index, "[" + part + "]");
                                partLen = len;
                                i = index;
                            }
                        }
                    }
                                   
                }
                output.Add(test);
            }
            return output;
        }

        
       
         class Tree<T> {
           public T value { get; set; }
           public Tree<T> left { get; set; }
           public Tree<T> right { get; set; }
         }


    }
}
