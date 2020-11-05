using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using System;

namespace Celerity.Native.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<InterlockedBenchmark>(ManualConfig.Create(DefaultConfig.Instance)
                .AddJob(Job.RyuJitX64));
        }
    }
}