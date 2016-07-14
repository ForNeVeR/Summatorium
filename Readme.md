Summatorium
============

This is a small benchmark.

Current results:

// * Summary *

- Host Process Environment Information:
- BenchmarkDotNet=v0.9.8.0
- OS=Microsoft Windows NT 6.2.9200.0
- Processor=Intel(R) Core(TM) i7 CPU 870 2.93GHz, ProcessorCount=8
- Frequency=2873497 ticks, Resolution=348.0080 ns, Timer=TSC
- CLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
- GC=Concurrent Workstation
- JitModules=clrjit-v4.6.1080.0

Type=Summator  Mode=Throughput  GarbageCollection=Concurrent Workstation

                      Method |    Median |    StdDev |
---------------------------- |---------- |---------- |
                       Naive | 2.9689 ms | 0.1829 ms |
                     Swapped | 6.5526 ms | 0.1163 ms |
                BitOptimized | 2.0861 ms | 0.0698 ms |
                   Unrolled4 | 3.1000 ms | 0.0474 ms |
          Unrolled4_distinct | 2.6676 ms | 0.0826 ms |
          Unrolled4_bitmagic | 1.9467 ms | 0.0263 ms |
 Unrolled4_distinct_bitmagic | 1.9437 ms | 0.0697 ms |