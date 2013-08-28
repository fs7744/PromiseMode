PromiseMode
===========

A Promise Mode for C#


	

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
