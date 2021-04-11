using System;
using System.Collections.Generic;
using System.Text;

namespace MyDictionaryClass
{
    class MyDictionaryClass<T1, T2>
    {
        T1[] key;
        T2[] value;

        public MyDictionaryClass()
        {
            key = new T1[0];
            value = new T2[0];
        }
        public void Add(T1 keyitem, T2 valueitem)
        {
            bool isKeyExist = ContainsKey(keyitem);
            if (!isKeyExist)
            {
                T1[] tempKey = key;
                T2[] tempValue = value;
                key = new T1[key.Length + 1];
                value = new T2[value.Length + 1];

                for (int i = 0; i < tempKey.Length; i++)
                {
                    key[i] = tempKey[i];
                }
                for (int i = 0; i < tempValue.Length; i++)
                {
                    value[i] = tempValue[i];
                }

                key[key.Length - 1] = keyitem;
                value[value.Length - 1] = valueitem;
            }

            else
            {
                throw new Exception("Same key already has been declared");
            }

        }
        public bool ContainsKey(T1 keyitem)
        {
            bool isThere = false;
            foreach (var item in key)
            {
                if (item.ToString() == keyitem.ToString())
                {
                    isThere = true;
                }
                else
                {
                    isThere = false;
                }
            }
            return isThere;
        }
        public bool ContainsValue(T2 valueitem)
        {
            bool isThere = false;
            foreach (var item in value)
            {
                if (item.ToString() == valueitem.ToString())
                {
                    isThere = true;
                }
                else
                {
                    isThere = false;
                }
            }
            return isThere;
        }
        public int KeyLength { get { return key.Length; } }
        public int ValueLength { get { return value.Length; } }
        public T1[] Keys { get { return key; } }
        public T2[] Values { get { return value; } }
    }
}
