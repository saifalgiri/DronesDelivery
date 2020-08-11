using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DronesDelivery
{
    class PriorityQueue<Priority, Value> 
    {
        private SortedDictionary<Priority, Queue<Value>> list = new SortedDictionary<Priority, Queue<Value>>();

        public void Enqueue(Priority priority, Value value)
        {
            Queue<Value> queue;

            if (!list.TryGetValue(priority, out queue))
            {
                queue = new Queue<Value>();

                list.Add(priority, queue);
            }

            queue.Enqueue(value);
        }

        public Value Dequeue()
        {
            var pair = list.First();

            var v = pair.Value.Dequeue();

            if (pair.Value.Count == 0) 
                list.Remove(pair.Key);

            return v;
        }

        public bool IsEmpty
        {
            get 
            { 
                return !list.Any();
            }
        }

    }

}