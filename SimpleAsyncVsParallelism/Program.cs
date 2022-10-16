
using System.Diagnostics;

Console.WriteLine("App started");

//Async Waiting for vars assigment => JUST ASYNC
//WORST PERFORMANCE
await WaitAndPrintAsync();


//Async Waiting for tasks => ASYNC + PARALLELISM
await WaitAndPrintParallelAsync();

//Async (Waiting for ALL tasks => ASYNC + PARALLELISM
await WaitAndPrintParallelAsyncWhenAll();


Console.ReadKey();

static async Task WaitAndPrint(string msg, int waitSeconds)
{
    await Task.Delay(waitSeconds * 1000);
    Console.WriteLine(msg);
}

static async Task WaitAndPrintAsync()
{
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("WaitAndPrintAsync started");
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    await WaitAndPrint("Four", 8);
    await WaitAndPrint("Three", 6);
    await WaitAndPrint("Two", 4);
    await WaitAndPrint("One", 2);
    Console.WriteLine($"WaitAndPrintAsync Elapsed: {stopWatch.Elapsed}");
}

static async Task WaitAndPrintParallelAsync()
{
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("WaitAndPrintParallelAsync started");
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    var t1 = WaitAndPrint("Four", 8);
    var t2 = WaitAndPrint("Three", 6);
    var t3 = WaitAndPrint("Two", 4);
    var t4 = WaitAndPrint("One", 2);
    await t1;
    await t2;
    await t3;
    await t4;
    Console.WriteLine($"WaitAndPrintParallelAsync Elapsed: {stopWatch.Elapsed}");
}

static async Task WaitAndPrintParallelAsyncWhenAll()
{
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("WaitAndPrintParallelAsync started");
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    var t1 = WaitAndPrint("Four", 8);
    var t2 = WaitAndPrint("Three", 6);
    var t3 = WaitAndPrint("Two", 4);
    var t4 = WaitAndPrint("One", 2);
    await Task.WhenAll(t1, t2, t3, t4);
    Console.WriteLine($"WaitAndPrintParallelAsyncWhenAll Elapsed: {stopWatch.Elapsed}");
}

