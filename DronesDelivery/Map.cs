using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DronesDelivery
{
	public class Map
	{
		public List<Nodes> nodeList = new List<Nodes>();
		public List<Nodes> Nodes => this.nodeList;

		public Map(){}
		
		public void Insert(Nodes n)
		{
			bool isExist = nodeList.Exists(x => x.Id == n.Id);
		    if(!isExist)nodeList.Add(n);
		}
		
		
		public void ConnectNodes(Nodes node1, Nodes node2, double cost)
		{

			if (nodeList.Exists(x => x.Id == node1.Id) && nodeList.Exists(x => x.Id == node2.Id))
			{
				node1.AddDirected(node2, cost);
				node2.AddDirected(node1, cost);
			}
			
		}

		public Nodes GetNode(string id)
        {
			return nodeList.Where(x => x.Id == id).First();
        }
        public void CreatGraph(Map map)
		{
			//  Add nodes to graph

			//drones
			Nodes drone1 = new Nodes("drone1: Metrostrasse 12", null, 51.234718, 6.825350, null);
			map.Insert(drone1);

			Nodes drone2 = new Nodes("drone2: Ludenberger Str. 1", null, 51.241370, 6.830320, null);
			map.Insert(drone2);


			//store
			Nodes store1 = new Nodes("store1: Willstätterstraße 24", null, 51.238400, 6.722420, null);
			map.Insert(store1);

			//for testing purpose , I provided other  address, replace lat and long of store2: Bilker Allee 128 to 51.663367, 7.841350

			//actual value for store2 = 51.210921, 6.77479
			Nodes store2 = new Nodes("store2: Bilker Allee 128", null, 51.210921, 6.77479, null);
			map.Insert(store2);

			Nodes store3 = new Nodes("store3: Hammer Landstraße 113", null, 51.203490, 6.721140, null);
			map.Insert(store3);

			Nodes store4 = new Nodes("store4: Gladbacher Str. 471", null, 51.225470, 6.690520, null);
			map.Insert(store4);

			Nodes store5 = new Nodes("store5: Lise-Meitner-Straße 1", null, 51.295750, 6.830080, null);
			map.Insert(store5);


			//customers
			Nodes customer1 = new Nodes("customer1: Friedrichstraße 133", null, 51.208404, 6.774550, null);
			customer1.IsCutomer = true;
			map.Insert(customer1);

			Nodes customer2 = new Nodes("customer2: Fischerstraße 23", null, 51.236681, 6.777098, null);
			customer2.IsCutomer = true;
			map.Insert(customer2);

			Nodes customer3 = new Nodes("customer3: Wildenbruchstraße 2", null, 51.227734, 6.759992, null);
			customer3.IsCutomer = true;
			map.Insert(customer3);

			Nodes customer4 = new Nodes("customer4 Reisholzer Str. 48", null, 51.207021, 6.832610, null);
			customer4.IsCutomer = true;
			map.Insert(customer4);


			// create edges 
			// C1 <-> Stores
			map.ConnectNodes(customer1, store1, CalculateDistance(customer1, store1));
			map.ConnectNodes(customer1, store2, CalculateDistance(customer1, store2));
			map.ConnectNodes(customer1, store3, CalculateDistance(customer1, store3));
			map.ConnectNodes(customer1, store4, CalculateDistance(customer1, store4));
			map.ConnectNodes(customer1, store5, CalculateDistance(customer1, store5));

			// C2 <-> Stores
			map.ConnectNodes(customer2, store1, CalculateDistance(customer2, store1));
			map.ConnectNodes(customer2, store2, CalculateDistance(customer2, store2));
			map.ConnectNodes(customer2, store3, CalculateDistance(customer2, store3));
			map.ConnectNodes(customer2, store4, CalculateDistance(customer2, store4));
			map.ConnectNodes(customer2, store5, CalculateDistance(customer2, store5));


			// C3 <-> Stores
			map.ConnectNodes(customer3, store1, CalculateDistance(customer3, store1));
			map.ConnectNodes(customer3, store2, CalculateDistance(customer3, store2));
			map.ConnectNodes(customer3, store3, CalculateDistance(customer3, store3));
			map.ConnectNodes(customer3, store4, CalculateDistance(customer3, store4));
			map.ConnectNodes(customer3, store5, CalculateDistance(customer3, store5));


			// C4 <-> Stores
			map.ConnectNodes(customer4, store1, CalculateDistance(customer4, store1));
			map.ConnectNodes(customer4, store2, CalculateDistance(customer4, store2));
			map.ConnectNodes(customer4, store3, CalculateDistance(customer4, store3));
			map.ConnectNodes(customer4, store4, CalculateDistance(customer4, store4));
			map.ConnectNodes(customer4, store5, CalculateDistance(customer4, store5));


			// S1 <-> Droes
			map.ConnectNodes(store1, drone1, CalculateDistance(store1, drone1));
			map.ConnectNodes(store1, drone2, CalculateDistance(store1, drone2));

			// S2 <-> Droes
			map.ConnectNodes(store2, drone1, CalculateDistance(store2, drone1));
			map.ConnectNodes(store2, drone2, CalculateDistance(store2, drone2));

			// S3 <-> Droes
			map.ConnectNodes(store3, drone1, CalculateDistance(store3, drone1));
			map.ConnectNodes(store3, drone2, CalculateDistance(store3, drone2));

			// S4 <-> Droes
			map.ConnectNodes(store4, drone1, CalculateDistance(store4, drone1));
			map.ConnectNodes(store4, drone2, CalculateDistance(store4, drone2));

			// S5 <-> Droes
			map.ConnectNodes(store5, drone1, CalculateDistance(store5, drone1));
			map.ConnectNodes(store5, drone2, CalculateDistance(store5, drone2));

		

		}

		public double CalculateDistance(Nodes firstNode, Nodes secondNode) 
		{
			double lat1 = Math.PI * firstNode.Latitude / 180;
			double lat2 = Math.PI * secondNode.Latitude / 180;

			double theta = firstNode.Longitude - secondNode.Longitude;
			double rtheta = Math.PI * theta / 180;
			double dist = Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(rtheta);
			dist = Math.Acos(dist);
			dist = dist * 180 / Math.PI;
			dist = dist * 60 * 1.1515;
			dist = dist * 1.609344;

			return dist;
		}

	}
}
