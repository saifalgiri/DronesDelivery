using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DronesDelivery
{
    public class Path<Node> 
    {
        public Node Last { get; private set; }
        public Path<Node> Previous { get; private set; }
        public double Distance { get; private set; }

        public Path(Node last, Path<Node> previous, double distance)
        {
            Last = last;

            Previous = previous;

            Distance = distance;
        }
        
        //first node to satrt with 
        public Path(Node start) : this(start, null, 0) { }

        public Path<Node> AddStep(Node step, double newDistance)
        {
            return new Path<Node>(step, this, Distance + newDistance);
        }

        public IEnumerator<Path<Node>> GetEnumerator()
        {
            for (Path<Node> p = this; p != null; p = p.Previous)
                yield return p;
        }


        // A* Algorithm 
        public dynamic FindPath ( Nodes start,Nodes destination,Func<Nodes, Nodes, double> distance)
        {
            var closed = new HashSet<Nodes>(); //visited list

            var queue = new PriorityQueue<double, Path<Nodes>>(); //open list for nodes that not been visited yet

            queue.Enqueue(0, new Path<Nodes>(start));// start from node 0, purposed node here is  drone node

            while (!queue.IsEmpty)
            {
                var path = queue.Dequeue();

                if (closed.Contains(path.Last))
                    continue;

                if (path.Last.Equals(destination))
                    return path;

                closed.Add(path.Last);

                // get current last step 
                Nodes check = (dynamic)path.Last.GetNeighbours().FirstOrDefault();

                //if current last step is a customer node, then proceed to compare between all stores and 
                // and destination customer, also skip checking with other customers nodes
                if (check.IsCutomer == true)
                {
                    double d = distance(path.Last, destination);

                    var newPath = path.AddStep(destination, d);

                    queue.Enqueue(newPath.Distance, newPath);
                }
                else
                {
                    foreach (Nodes n in path.Last.GetNeighbours())
                    {
                        double d = distance(path.Last, n);

                        var newPath = path.AddStep(n, d);

                        queue.Enqueue(newPath.Distance, newPath);
                    }
                }


            }

            return null;
        }
    }
}
