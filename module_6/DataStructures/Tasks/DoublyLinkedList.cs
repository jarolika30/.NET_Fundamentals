using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private List<T> list = new List<T>();
        public int Length => list.Count;

        public void Add(T e)
        {
            list.Add(e);
        }

        public void AddAt(int index, T e)
        {
            list.Insert(index, e);
        }

        public T ElementAt(int index)
        {
            T item;

            try
            {
                item = list[index];
            }
            catch
            {
                throw new IndexOutOfRangeException();
            }

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T>.Enumerator em = list.GetEnumerator();

            return em;
        }

        public void Remove(T item)
        {
            list.Remove(item);
        }

        public T RemoveAt(int index)
        {
            T item;

            try
            {
                item = list[index];
                list.RemoveAt(index);
            }
            catch
            {
                throw new IndexOutOfRangeException();
            }

            return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
