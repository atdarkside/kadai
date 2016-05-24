//Coder :TATa
//ごり押し
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSearch__d1 {
    class Program {
        static void Main(string[] args) {
            FileStream fs = File.OpenRead("B:YOMIGANA_SORT_TENPO.txt");
            StreamReader sr = new StreamReader(fs,Encoding.GetEncoding("Shift_JIS"));
            long startPos = fs.Length / 42 * 3;
            fs.Seek(startPos,SeekOrigin.Begin);

            Console.Write("支店番号:");
            int searchNO = int.Parse(Console.ReadLine());

            string line;
            while(true) {
                line = sr.ReadLine();
                int NO = new int();
                
                try {
                    NO = int.Parse(line.Substring(1, 2));
                }
                catch {
                    Console.WriteLine("その支店番号は存在しません。");
                    break;
                }
                
                if(NO == searchNO) {
                    Console.WriteLine("┌─┬─────┬──────────┬─────┬───────────────┬───────┐");
                    Console.WriteLine("│NO│支店名    │よみがな            │郵便番号  │住所                          │電話番号      │");
                    Console.WriteLine("├─┼─────┼──────────┼─────┼───────────────┼───────┤");
                    Console.WriteLine(line);
                    Console.WriteLine("└─┴─────┴──────────┴─────┴───────────────┴───────┘");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
