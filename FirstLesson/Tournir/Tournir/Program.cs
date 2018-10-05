using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//2 режим: имяТурнира id
//1 режим: имяТурнира Список участников
namespace Tournir
{
    public class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            switch (type)
            {
                case "CreateTurnir":
                    CreateTournir(GetData());
                break;
                case "ChouseWinner":
                    ChouseWinner(GetData());
                break;
                default:
                    Console.WriteLine("error");
                break;

            }
        }
        public static void CreateTournir(string[] data)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllLines(path + @"/Tournirs/" + data[0]+".txt",new string[] { ParseOnPare(data[1]) });
        }
        public static void ChouseWinner(string[] data)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] input = File.ReadAllLines(path + @"/Tournirs/" + data[0] + ".txt");

        }
        public static string ParseOnPare(string str)
        {
            string[] names = str.Split(' ');
            string[] pares = new string[names.Length / 2];
            for (int i = 0; i < pares.Length; i++)
            {
                pares[i] = names[2 * i] + " " + names[2 * i + 1];
            }
            return string.Join(",", pares);
        }
        public static string[] GetData()
        {
            string[] output = new string[2];
            Console.WriteLine("Enter name of Tournir");
            output[0] = Console.ReadLine();
            Console.WriteLine("Enter names separating with space, orr name of winner in pare");
            output[1] = Console.ReadLine();
            if (!IsPowOfTwo(output[1].Split(' ').Length))
            {
                Console.WriteLine("count of names must be power of two");
                return GetData();
            } 
            return output;
        }
        public static bool IsPowOfTwo(int num)
        {
            if ((num < 0) || (num == 1)) return false;
            int rem = 0;
            while ((num !=1) && (rem == 0))
            {
                rem = num % 2;
                num /= 2;
            }
            if ((num == 1) && (rem == 0)) return true;
            else return false;
        }
        
    }

    
}
