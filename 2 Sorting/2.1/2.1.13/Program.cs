﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._13
{
    /*
     * 2.1.13
     * 
     * 纸牌排序。说说你会如何将一副扑克牌按花色排序（花色排序是黑桃、红桃、梅花和方片），
     * 限制条件是所有牌都是背面朝上排成一列，
     * 而你一次只能翻看两张牌或者交换两张牌（保持背面朝上）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 我这种懒（zhi）人（zhang）自然是冒泡啦 _(:з)∠)_
            // 翻一二两张，是逆序对就交换，否则什么也不做
            // 翻二三两张，是逆序对就交换，否则什么也不做
            // 一直到最后，可以保证最右侧的是最大花色的牌
            // 然后不断重复上述过程，就可以完全排序
        }
    }
}
