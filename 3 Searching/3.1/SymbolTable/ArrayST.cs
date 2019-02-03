﻿using System;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 符号表（数组实现）。
    /// </summary>
    /// <typeparam name="Key">键类型。</typeparam>
    /// <typeparam name="Value">值类型。</typeparam>
    public class ArrayST<Key, Value> : IST<Key, Value> 
    {
        private Key[] keys;             // 键数组
        private Value[] values;         // 值数组
        private int n = 0;              // 键值对数目

        /// <summary>
        /// 建立基于数组实现的符号表。
        /// </summary>
        public ArrayST() : this(8) { }

        /// <summary>
        /// 建立基于数组实现的符号表。
        /// </summary>
        /// <param name="initCapacity">初始大小。</param>
        public ArrayST(int initCapacity)
        {
            this.keys = new Key[initCapacity];
            this.values = new Value[initCapacity];
        }

        /// <summary>
        /// 检查键 <typeparamref name="Key"/> 是否存在。
        /// </summary>
        /// <param name="key">需要检查是否存在的键。</param>
        /// <returns></returns>
        public bool Contains(Key key) => Get(key).Equals(default(Key));

        /// <summary>
        /// 删除键 <paramref name="key"/> 及对应的值。
        /// </summary>
        /// <param name="key">需要删除的键。</param>
        public void Delete(Key key)
        {
            for (int i = 0; i < this.n; i++)
            {
                if (key.Equals(this.keys[i]))
                {
                    this.keys[i] = this.keys[this.n - 1];
                    this.values[i] = this.values[this.n - 1];
                    this.keys[this.n - 1] = default(Key);
                    this.values[this.n - 1] = default(Value);
                    this.n--;
                    if (this.n > 0 && this.n == this.keys.Length / 4)
                        Resize(this.keys.Length / 2);
                    return;
                }
            }
        }

        /// <summary>
        /// 获取键对应的值，若键不存在则返回 null。
        /// </summary>
        /// <param name="key">需要查找的键。</param>
        /// <returns></returns>
        public Value Get(Key key)
        {
            for (int i = 0; i < this.n; i++)
                if (this.keys[i].Equals(key))
                    return this.values[i];
            return default(Value);
        }

        /// <summary>
        /// 检查符号表是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 获得包含全部键的集合。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Key> Keys()
        {
            Key[] result = new Key[this.n];
            Array.Copy(this.keys, result, this.n);
            return result;
        }

        /// <summary>
        /// 向符号表中插入新元素，若键存在将被替换。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public void Put(Key key, Value value)
        {
            Delete(key);

            if (this.n >= this.values.Length)
                Resize(this.n * 2);

            this.keys[this.n] = key;
            this.values[this.n] = value;
            this.n++;
        }

        /// <summary>
        /// 返回符号表中键值对的数量。
        /// </summary>
        /// <returns>键值对数量。</returns>
        public int Size() => this.n;

        /// <summary>
        /// 为符号表重新分配空间。
        /// </summary>
        /// <param name="capacity">新分配的空间大小。</param>
        private void Resize(int capacity)
        {
            Key[] tempKey = new Key[capacity];
            Value[] tempValue = new Value[capacity];

            for (int i = 0; i < this.n; i++)
                tempKey[i] = this.keys[i];
            for (int i = 0; i < this.n; i++)
                tempValue[i] = this.values[i];

            this.keys = tempKey;
            this.values = tempValue;
        }
    }
}
