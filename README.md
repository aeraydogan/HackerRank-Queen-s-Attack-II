# HackerRank-Queen-s-Attack-II
There are two different approaches for a solution.

One of them is calculating all of the possible moves and ignoring all of the obstacles in all directions.  When obstacle is entered, one must calculate new moves that count just for that direction(it is important to Consider whether there are any earlier obstacles in that direction ).

The other solution  is that after storing all obstacles in the hashtable, one must increase the queen's position one by one in every direction and increase the movement count. When you come across an obstacle, break loop and change the queen's direction.

I have chosen the first one because it has just one for-loop. We can calculate movement count when we are taking obstacle inputs. In contrast, the second solution requires that , after we take an obstacle we have to turn another for-loop to calculate movements.

Actually, I implemented both of the solutions and calculated performance issues. The first solution has better value for time and ram size.

