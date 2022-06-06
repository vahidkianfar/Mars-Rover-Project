# Mars-Rover-Project

## Assumptions:

1. For Rectangular Plateau: size "0 0" means only One block, and 0 is the starting point.

2. I assumed the Rovers are deployed and moved one by one, but I've created methods for
   checking "DeploymentCollision" but for now I only Use the Collision method for "SamePosition" it means the Rover cannot be on the same position.
  
3. I've implemented "GetRoverPosition" inside the Rover class (not the "MissionControl" class, because I'm thinking about expanding the project
   for Obsticles, possible errors and rover's broke down.

## Key Features:

1. This project is highly expandable (I've created interfaces for Vehicles, Surfaces, Movements, Positions, NavigationSystem).
2. Rovers can move Backward and Forward.
3. Rovers can move in Diagonal path for Direction [NW, NE, SW, SE].

   ![](https://github.com/vahidkianfar/Mars-Rover-Project/blob/master/Mars-Rover-Project/Gif/Rover-Diagonal.gif)


4. MissionControl class can store a List of Rovers.
5. I've created methods for "CollisionDetection"
6. Drawing Live Table, after the user created and deployed the rovers, it will draw a LiveTable of Plateau and Rovers.
7. User can use File for creating a plateau, deploying rovers and execute movement commands.
8. So far the project only accepts one kind of rover but with the interface "IVehicle" anyone can expand the project for other type of rovers.
9. You can expand the Movement of the rover (Move Left, Move Right).



## Menu:

1. User can enter the instructions into file or read instructions from file:

![](https://github.com/vahidkianfar/Mars-Rover-Project/blob/master/Mars-Rover-Project/Gif/Rover-File.gif)

2. User can enter the instructions manually:

![](https://github.com/vahidkianfar/Mars-Rover-Project/blob/master/Mars-Rover-Project/Gif/Rover-Manually.gif)


## Instructions Format:

1. User needs to set the Plateau size in form of "X Y" e.g "10 10" then it creates a surface (so far, rectangular plateau) in size of 10x10.
2. User gives the number of rovers to the Controller [number of Rovers must be between 1 and maximum number of surface blocks, if the surface is 6x6 it means the number of rovers cannot be more than 36].
3. User should set the deployment coordinates and direction of the Rover "X Y CompassDirection" e.g "3 5 N" it means the rover will be deploy at
   coordinates (3,5) on the surface facing to the North (N=North, W=West, S=South, E=East, NW=North West, NE=North East, SW=South West, SE= South East).
 
4. Now user must enter the movement's instructions, e.g "BLRM":

      -B: Rotate the rover 180 degree at the current position, e.g. (1,2,N) --B--> (1,2,S).
  
      -L: Rotate the rover 90 degrees to the left, e.g. (1,2,N)--L--> (1,2,W).
  
      -R: Just like "L" but it rotates the rover's direction 90 degrees to the right e.g. "N" --R--> "E".
  
      -M: Move the rover forward (based on the rover's direction) e.g. (1,2,E) --M--> (2,2,E).
      
      -V: Move the rover backward (based on the rover's direction) e.g. (1,1,N) --V--> (1,0,N).
 
  
  
5. Then system will create a LiveTable and shows the Plateau and each Rover's position.

