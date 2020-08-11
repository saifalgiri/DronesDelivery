using System;
using System.Collections.Generic;
using System.Linq;

namespace DronesDelivery
{
    public class Program 
    {
        static void Main(string[] args)
        {
            do
            {
                // isntance  of the Graph class 
                Map graph = new Map();

                //istance for path finding 
                var pathObj = new Path<Nodes>(null, null,  0.0);
                
                //fill the  graph with vertexes and edges 
                graph.CreatGraph(graph);

                List<Path<Nodes>> list = new List<Path<Nodes>>();
                string destination = string.Empty;

                // List  of customers address
                var customers = graph.Nodes.OrderBy(x => x.Id).ToList().Where(x => x.Id.Contains("customer"));
                foreach (Nodes n in customers)
                {
                    Console.WriteLine(n.Id);
                }

                
                do
                {
                    Console.WriteLine("Enter destination address from customer list above: \n");

                    destination = Console.ReadLine();
                }
                while (!graph.Nodes.Exists(x => x.Id == destination));

                Nodes destinationNode = graph.GetNode(destination);

                // check distance between two nodes.
                Func<Nodes, Nodes, double> distance = (first, second) =>
                                                     first.Neighbors.Cast<ConnectNodes>().Single(
                                                         i => i.Neighbor.Id == second.Id).Cost;


                Path<Nodes> shortestPath1 = pathObj.FindPath(graph.GetNode("drone1: Metrostrasse 12"), destinationNode, distance);
                Path<Nodes> shortestPath2 = pathObj.FindPath(graph.GetNode("drone2: Ludenberger Str. 1"), destinationNode, distance);

                Console.WriteLine("\nThe fastest way is \n");

                double totalCost1 = shortestPath1.Distance;
                double totalCost2 = shortestPath2.Distance;

                //compare 2 shortest path and print the one with less coast 
                Path<Nodes> shortest = totalCost1 <= totalCost2 ? shortestPath1 : shortestPath2;

                foreach( var item in shortest)
                {
                    list.Add(item);
                }

                list.Reverse();
                foreach (Path<Nodes> step in list)
                {
                    if (step.Previous != null)
                    {
                        Console.WriteLine(string.Format("From {0}  to  {1} => {2:#.####} KM",
                                          step.Previous.Last.Id, step.Last.Id, step.Distance));
                    }
                }

                Console.WriteLine("\nDrone takes  ({0}  Minutes) to deliver goods",
                    TimeSpan.FromMinutes(shortest.Distance).ToString("mm\\:ss"));

                Console.WriteLine("--------------------------------------");
                Console.WriteLine("\nTry again? Yes or No? \n");

            }
            while (Console.ReadLine().ToLower() == "yes");
        }

    }
}
