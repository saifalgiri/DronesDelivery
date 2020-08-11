<h2 align="center">Drone Delivery Path Finder<h2>

<h3 align="center">Analysis<h3> 
      <p> Algorithm needs connected nodes (tree), so after some studies and analysis I have generated the following two diagrams, each diagram shows how customers connect to stores and how stores connect to drones.  Both Diagrams represent the map that Algorithm will use to find shortest path.
 Please note that distance number between nodes shown in below diagrams taken from google map manually and just used for testing, however our system calculates distance automatically based on Latitude and Longitude, so the accuracy is 99.97%. </p>

<h4 align="center">Customer1 and Customer2<h4>
  
![Optional Text](../master/DronesDelivery/Images/customer1.png)

<h4 align="center">Customer3 and Customer4<h4>
  
![Optional Text](../master/DronesDelivery/Images/customer2.png)

<h3 align="center">Algorithm<h3> 
     <p> I used A* Algorithm because it is one of the best algorithm in term of accuracy and performance. It is the best deep first search algorithm due to it finds the next node greedily.  A* algorithm optimizes the search by using heuristic function, and is useful to be used in our case because we need to find path in actual geographical map.
Please find more details about how algorithm works from comments inside code. 
<h3 align="center">How to run application <h3>
  <p>
<br> -	Simply build the code and make sure it build successfully 
<br> -	Run application, application is a console application so once code run the console window will popup </p>

![Optional Text](../master/DronesDelivery/Images/pic1.png) 

<br> -	Copy one customer address as it is from list and paste it as destination like below example. 
 

 ![Optional Text](../master/DronesDelivery/Images/pic2.png) 

<br> -	The shortest path will print all required details like drone depot, store , distance in km, customer, and time  
 
 ![Optional Text](../master/DronesDelivery/Images/pic3.png) 

<br> Notes: I use short names for the addresses provided for simplicity.
<br> Notes: Most of result will lead to store2 because it is the nearest to all stores and customers, in order to test other stores then you need to update store2 latitude and longitude as shown in las image. 

<br> The store address that I provided for testing is far than other stores addresses. 
 

 ![Optional Text](../master/DronesDelivery/Images/pic4.png) 

</p>
<h1 align="center"> Thank You <h1>




