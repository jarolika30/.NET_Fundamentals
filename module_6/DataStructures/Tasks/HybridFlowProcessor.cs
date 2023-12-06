using System;
using Tasks.DoNotChange;
using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> list = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            if (list.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return list.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            int index = list.Length;

            list.AddAt(index, item);
        }

        public T Pop()
        {
            if (list.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return list.RemoveAt(0);
        }

        public void Push(T item)
        {
            int index = list.Length;

            list.AddAt(index, item);
        }
    }
}
