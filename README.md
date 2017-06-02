# HackerRank-Queen-s-Attack-II
HackerRank-Queen-s-Attack-II

There are two different approach for solution. 

One of them is that calculating all possible moves ignoring all of obstacles for all directions, And when obstacle is entered, calculate new moves count just for that direction(Consider, whether there is any earlier obstacle at that direction ). 

Other one is that after storing all obstacles in hashtable, increase queen's position one by one for every directions and increase movement count. When you come across an obstacle, break loop and change queen's direction.

I have chose the first one. Because first one has just one for-loop.We can calculate movements count when we are taking obstacle inputs. For secound one, after we take obstacle we have to turn another for-loop for calculating movements. 

Acually, I implemented both of solutions. And I calculated performance issues. First solution has better value for time and ram size.
