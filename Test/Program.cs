using PromiseMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program 
    {
        static void Main(string[] args)
        {
            PromiseFactory.When(i =>
            {
                i.Next(0);
            }).Then<int>((i,result) =>
            {
                Add(result, 1, j => i.Next(j));
            }).Then<int>((i,result) =>
            {
                Add(result, 2, j => i.Next(j));
            }).Then<int>((i,result) =>
            {
                Console.WriteLine(result);
            }).Start();

            Console.ReadKey();
        }

        static void Add(int x,int y,Action<int> callBack)
        {
            callBack(x + y);
        }
    }
}
