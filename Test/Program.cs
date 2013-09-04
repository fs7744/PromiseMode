using PromiseMode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program 
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            var p = new Promise().Then(i =>
            {
                i.Next(0);
            }).Then<int>((i, result) =>
            {
                Add(result, 1, j => i.Next(j));
            }).Then<int>((i, result) =>
            {
                Add(result, 2, j => i.Next(j));
            });

            watch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                p.Start();
            }

            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static void Add(int x,int y,Action<int> callBack)
        {
            callBack(x + y);
        }
    }
}
