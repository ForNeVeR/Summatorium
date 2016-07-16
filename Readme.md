Summatorium
============

This is a small benchmark.

Current results:

```
// * Summary *

Host Process Environment Information:
BenchmarkDotNet=v0.9.8.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7 CPU 870 2.93GHz, ProcessorCount=8
Frequency=2873496 ticks, Resolution=348.0081 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1080.0

Type=Summator  Mode=Throughput  GarbageCollection=Concurrent Workstation
```

                       Method |    Median |    StdDev |
----------------------------- |---------- |---------- |
                        Naive | 3.5050 ms | 0.2918 ms |
                      Swapped | 6.9144 ms | 0.1338 ms |
      Swapped_SimpleEarlyExit | 7.2350 ms | 0.1311 ms |
   Swapped_SimpleRowEarlyExit | 6.5308 ms | 0.0692 ms |
                 BitOptimized | 1.9903 ms | 0.0186 ms |
                    Unrolled4 | 2.9571 ms | 0.0377 ms |
    Unrolled4_SimpleEarlyExit | 4.3367 ms | 0.0819 ms |
 Unrolled4_SimpleRowEarlyExit | 2.9424 ms | 0.0347 ms |
           Unrolled4_distinct | 2.6884 ms | 0.0531 ms |
           Unrolled4_bitmagic | 1.9882 ms | 0.0188 ms |
  Unrolled4_distinct_bitmagic | 2.0029 ms | 0.0215 ms |
    Unrolled4_TrickyEarlyExit | 3.2228 ms | 0.0389 ms |
