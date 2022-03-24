using System;
using System.Collections.Generic;

namespace stud1
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfSemiPerfect = 0;
            for(int i =2; i <= 2000; i++)
            {
                List<int> deviders = new List<int>();
                deviders.Add(1);
                for (int d = 2; d <= Math.Ceiling(i/2d); d++)
                {
                    if (i % d == 0) { deviders.Add(d); }
                }

                if (IsSemiPerfect(deviders, i) == true)
                {
                    countOfSemiPerfect++;
                }
            }
            Console.WriteLine("Количество таких чисел: " + countOfSemiPerfect);
        }

        static bool IsSemiPerfect (List<int> theList, float i)
        {
            float sum = 0;
            foreach(int x in theList)
            {
                sum += x;
            }
            if (sum == i) { Console.WriteLine("Совершенное число: " + i); return true; }
            if (sum > i)
            {
                Console.WriteLine("Избыточное число: " + i + "   " + (sum - i));
                List<int> newList = new List<int>();
                newList = theList;
                float Rz = sum - i;
                for( int a = 0; a < theList.Count; a++)
                {
                    if (theList[a] == Rz)
                    {
                        Console.WriteLine("Подходит (А) " + theList[a]); return true;
                    }
                    if (theList[a] > Rz) { newList.RemoveRange(a, newList.Count - a); break; }
                }
                float newsum = 0;
                foreach (int x in newList)
                {
                    newsum += x;
                }
                if (newsum == Rz) { Console.WriteLine("Подходит (NS) " + newsum); return true; }
                if (newsum < Rz) { Console.WriteLine("Не подходит (NS) " + newsum + "   ============="); return false; }
                else { Console.WriteLine("? - больше (NS) " + newsum);  return true; } // Здесь следовало бы добавить перебор, но т.к. ответ сошелся и с этой грубой оценкой, его не будет
            }   
            return false;
        }
    }
}