﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._32
{
    /*
     * 1.4.32
     * 
     * 均摊分析。
     * 请证明，对一个基于大小可变的数组实现的空栈的 M 次操作访问数组的次数和 M 成正比。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 首先，不需要扩容数组的的操作都只需访问数组一次，M 次操作就是 M 次访问。
            // 随后我们有性质， M 次栈操作后额外复制访问数组的次数小于 2M。
                // 这里简单证明，设 M 次操作之后栈的大小为 n，那么额外访问数组的次数为：
                // S = n/2 + n/4 + n/8 +...+ 2 < n
                // 为了能使栈大小达到 n，M 必须大于等于 n/2
                // 因此 2M >= n > S，得证。               
            // 因此我们可以得到 M 次操作后访问数组次数的总和 S' = S + M < 3M
            // 得证。
        }
    }
}