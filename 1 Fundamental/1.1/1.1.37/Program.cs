﻿using System;

namespace _1._1._37
{
    class Program
    {
        // 使用 0~N-1 的随机数会导致每次交换的数字可能相同
        // 例如：
        // 原数组： 1 2 3 4
        // 第一次： 2 1 3 4 random = 1，第 0 个和第 1 个交换
        // 第二次： 1 2 3 4 random = 0，第 1 个和第 0 个交换
        static void Main(string[] args)
        {
            var M = 10;     // 数组大小
            var N = 100000; // 打乱次数
            var a = new int[10];

            var result = new int[M, M];

            for (var i = 0; i < N; i++)
            {
                // 初始化
                for (var j = 0; j < a.Length; j++)
                {
                    a[j] = j;
                }

                // 打乱
                Shuffle(a, i);

                // 记录
                for (var j = 0; j < M; j++)
                {
                    result[a[j], j]++;
                }
            }

            PrintMatrix(result);
        }

        /// <summary>
        /// 打乱数组（不够好的版本）。
        /// </summary>
        /// <param name="a">需要打乱的数组。</param>
        /// <param name="seed">用于生成随机数的种子值。</param>
        static void Shuffle(int[] a, int seed)
        {
            var N = a.Length;
            var random = new Random(seed);
            for (var i = 0; i < N; i++)
            {
                // int r = i + random.Next(N - i);
                var r = random.Next(N); // 返回的是 0 ~ N-1 之间的随机整数
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// 在控制台上输出矩阵。
        /// </summary>
        /// <param name="a">需要输出的矩阵。</param>
        public static void PrintMatrix(int[,] a)
        {
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"\t{a[i, j]}");
                }
                Console.Write("\n");
            }
        }
    }
}