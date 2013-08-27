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
                i.Next(result + 1);
            }).Then<int>((i,result) =>
            {
                i.Next(result + 2);
            }).Then<int>((i,result) =>
            {
                Console.WriteLine(result);
                i.Next();
            }).Start();

            Console.ReadKey();
        }
    }
}
