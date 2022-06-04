# Mars-Rover-Project
This Project contains two-part-menu:



1. User can enter the instruction into file or read instruction from file:

![](https://github.com/vahidkianfar/Mars-Rover-Project/blob/master/Mars-Rover-Project/Gif/Rover-File.gif)

2. User can enter the instructions manually:

![](https://github.com/vahidkianfar/Mars-Rover-Project/blob/master/Mars-Rover-Project/Gif/Rover-Manually.gif)

## Instruction Format:
1. User needs to set the Plateau size in form of "X X" e.g "10 10" then it creates a surface (so far, rectangular plateau) in size of 10x10.
2. User give the number of rovers to the Controller [number of Rovers must be between 1 and maximum number of surface blocks, if the surface is 6x6 it means the number of rovers cannot be more than 36].
3. User should set the deployment coordinates and direction of the rotate "X X Compass Direction" e.g "3 5 N" it means the rover will be deploy at
   coordinates (3,5) on the surface facing to the North (N=North, W=West, S=South, E=East).
 
4. Now user must enter the movement's instructions, e.g "BLRM":

      -B: turn the rover 180 degree at the current position, e.g. (1,2,N) --"B"--> (1,2,S).
  
      -L: turn the rover 90 degrees to the left, e.g. (1,2,N)--"L"--> (1,2,W).
  
      -R: just like "L" but it turns the rover direction 90 degrees to the right e.g. "N" --"R"--> "E".
  
      -M: move the rover forward (based on the rover's direction) e.g. (1,2,E) --"M"--> (2,2,E).
 
  
  
5. Then system will create a LiveTable and show the Plateau and each Rover's position.
