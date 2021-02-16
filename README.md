# Mine Sweeper code writing exercise

Author: Gururaj Kulkarni
Date: 16-Feb-2021
-------------------------------------------------------

Problem:

A field of N x M squares is represented by N lines of 
exactly M characters each. The character '*' represents 
a mine and the character '.' represents no-mine. 

Example input (a c x 4 mine-field of 12 squares, 2 of
which are mines)

```
3 4

*...
..*.
....



Your task is to write a program to accept this input and
produce as output a hint-field of identical dimensions 
where each square is a * for a mine or the number of 
adjacent mine-squares if the square does not contain a mine. 

Example output (for the above input)
```
*211
12*1
0111


-------------------------------------------------------
Solution:
MineResult.cs Logic to find number of mines. 

MineResultTest: UT project
