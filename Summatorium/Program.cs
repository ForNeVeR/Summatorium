using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Summatorium
{
    public class Summator
    {
        private const int N = 1000;
        private readonly byte[,] _array = new byte[N, N];

        public Summator()
        {
            for (int x = 0; x < N; ++x)
            {
                var a = new byte[N];
                new Random(100500).NextBytes(a);
                for (int y = 0; y < N; ++y)
                {
                    _array[x, y] = a[y];
                }
            }
        }

        [Benchmark]
        public int Naive()
        {
            int count = 0;
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if (_array[i, j] > 128)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        [Benchmark]
        public int Swapped()
        {
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (_array[i, j] > 128)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        [Benchmark]
        public int BitOptimized()
        {
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    count += _array[i, j] >> 7;
                }
            }

            return count;
        }

        [Benchmark]
        public int Unrolled4()
        {
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j += 4)
                {
                    if (_array[i, j] > 128) { count++; }
                    if (_array[i, j + 1] > 128) { count++; }
                    if (_array[i, j + 2] > 128) { count++; }
                    if (_array[i, j + 3] > 128) { count++; }
                }
            }

            return count;
        }

        [Benchmark]
        public int Unrolled4_distinct()
        {
            int count0 = 0, count1 = 0, count2 = 0, count3 = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j += 4)
                {
                    if (_array[i, j] > 128) { count0++; }
                    if (_array[i, j + 1] > 128) { count1++; }
                    if (_array[i, j + 2] > 128) { count2++; }
                    if (_array[i, j + 3] > 128) { count3++; }
                }
            }

            return count0 + count1 + count2 + count3;
        }

        [Benchmark]
        public int Unrolled4_bitmagic()
        {
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j += 4)
                {
                    count += _array[i, j] >> 7;
                    count += _array[i, j + 1] >> 7;
                    count += _array[i, j + 2] >> 7;
                    count += _array[i, j + 3] >> 7;
                }
            }

            return count;
        }

        [Benchmark]
        public int Unrolled4_distinct_bitmagic()
        {
            int count0 = 0, count1 = 0, count2 = 0, count3 = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j += 4)
                {
                    count0 += _array[i, j] >> 7;
                    count1 += _array[i, j + 1] >> 7;
                    count2 += _array[i, j + 2] >> 7;
                    count3 += _array[i, j + 3] >> 7;
                }
            }

            return count0 + count1 + count2 + count3;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Summator>();
        }
    }
}
