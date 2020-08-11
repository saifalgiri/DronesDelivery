using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DronesDelivery
{
    public class ConnectNodes
    {
        public Nodes Neighbor { get; set; }
        public double Cost { get; set; }
    }
    public partial class Nodes
    {

        public string Id { get; private set; }
        public object Data { get; set; }
        public List<ConnectNodes> Neighbors { get;  set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

       public bool IsCutomer { get; set; }

        public Nodes(string nodeId, object data, double latitude, double longitude, List<ConnectNodes> neighbors)
        {
            Id = nodeId;
            Data = data;
            Latitude = latitude;
            Longitude = longitude;
            Neighbors = neighbors == null ? new List<ConnectNodes>() : neighbors;

        }

        public void AddDirected(Nodes n, double cost)
        {
            var neighbor = new ConnectNodes {  Neighbor = n, Cost = cost};
            Neighbors.Add(neighbor);
        }

        public List<Nodes> GetNeighbours()
        {

            List<Nodes> nodes = new List<Nodes>();

            foreach (var n in Neighbors)
            {
                nodes.Add(n.Neighbor);
            }

            return nodes;
        }
    }
}
