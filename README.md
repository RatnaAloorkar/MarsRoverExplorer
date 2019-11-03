# MarsRoverExplorer
Explore Mars with rovers

Problem Statement =>
A rover’s position and location is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.
In order to control a rover , NASA sends a simple string of letters. The possible letters are ‘L’, ‘R’ and ‘M’. ‘L’ and ‘R’ makes the rover spin 90 degrees left or right respectively, without moving from its current spot. ‘M’ means move forward one grid point, and maintain the same heading.
Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
Expected Output:
1 3 N
5 1 E

Solution =>

Assumptions:
- Already two rovers are present on Mars.
- Second rover can only move after first rover has stopped moving.
- User can only move the rovers once.

The solution contains two projects:
1. MarsExploration: It is a console application, which contains the solution of this problem.
2. MarsExploration.Tests: This project contains tests for MarsExploration project.

How to run the program:
- Open solution in Visual Studio 2017 or more.
- Set MarsExploration project as start up project
- Press F5

User experience:
- User is first asked the dimensions of the grid to divide Mars into.
- User is then asked to set the initial position on Rover 1.
- User is asked to enter instructions to move Rover 1.
- User is asked to set the initial position on Rover 2.
- User is asked to enter instructions to move Rover 2.
- Result is displayed.
- If the user's instructions cause the Rovers to move out of the grid, then the operation is aborted.
