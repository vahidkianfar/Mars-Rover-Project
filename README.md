# Mars-Rover-Project
## Assumptions:

1. I assumed the Rovers are deployed and moved one by one, but I've created methods for
   checking "DeploymentCollision" but for now I only Use the Collision method for "SamePosition".

## Key Features:

1. MissionControl class can store a List of Rovers.
2. I've created methods for "CollisionDetection"
3. Drawing Live Table, after the user created and deployed the rovers, it will draw a LiveTable of Plateau and Rovers.
4. User can use File for creating a plateau, deploying rovers and execute movement commands.
5. So far the project only accepts one kind of rover but with the interface "IVehicle" anyone can expand the project for other type of rovers.
6. You can expand the Movement of the rover (Move Backward, Move Left, Move Right).
7. You can add other directions, e.g. "NW" for North-West.


## Menu:

1. User can enter the instruction into file or read instruction from file:

![](https://github.com/vahidkianfar/Mars-Rover-Project/blob/master/Mars-Rover-Project/Gif/Rover-File.gif)

2. User can enter the instructions manually:

![](https://github.com/vahidkianfar/Mars-Rover-Project/blob/master/Mars-Rover-Project/Gif/Rover-Manually.gif)


## Instruction Format:

1. User needs to set the Plateau size in form of "X X" e.g "10 10" then it creates a surface (so far, rectangular plateau) in size of 10x10.
2. User gives the number of rovers to the Controller [number of Rovers must be between 1 and maximum number of surface blocks, if the surface is 6x6 it means the number of rovers cannot be more than 36].
3. User should set the deployment coordinates and direction of the Rover "X X Compass Direction" e.g "3 5 N" it means the rover will be deploy at
   coordinates (3,5) on the surface facing to the North (N=North, W=West, S=South, E=East).
 
4. Now user must enter the movement's instructions, e.g "BLRM":

      -B: turn the rover 180 degree at the current position, e.g. (1,2,N) --"B"--> (1,2,S).
  
      -L: turn the rover 90 degrees to the left, e.g. (1,2,N)--"L"--> (1,2,W).
  
      -R: just like "L" but it turns the rover direction 90 degrees to the right e.g. "N" --"R"--> "E".
  
      -M: move the rover forward (based on the rover's direction) e.g. (1,2,E) --"M"--> (2,2,E).
 
  
  
5. Then system will create a LiveTable and show the Plateau and each Rover's position.

