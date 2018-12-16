using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T9.Parser;
using T9.Reader;

namespace T9
{
    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please select an option from below:");
                Console.WriteLine("1. Press 1 for small dataset");
                Console.WriteLine("2. Press 2 for large dataset");
                Console.WriteLine("3. Press any 3 to exit");
                Console.WriteLine("4. Press any other key to exit");

                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                
                string rawString = string.Empty;
                bool isLarge = false;
                if (key == '1')
                {
                    rawString = T9FileOperation.GetSmallFileData();
                }
                else if (key == '2')
                {
                    rawString = T9FileOperation.GetLargeFileData();
                    isLarge = true;
                }
                else if (key == '3')
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }

                if (rawString != string.Empty)
                {
                    DictionarySearch dictionary = new DictionarySearch();

                    dictionary.InsertFromRaw(rawString);

                    Console.WriteLine(dictionary.ToString());
                    T9FileOperation.SaveOutputFile(isLarge, dictionary.ToString());
                    Console.WriteLine(string.Format("Output file saved at {0}", T9FileOperation.OutputPath));

                    Console.WriteLine("");
                }
            }
        }
    }
}
