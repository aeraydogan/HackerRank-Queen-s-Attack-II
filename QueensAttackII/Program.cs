using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    enum Directions{
        North,
        South,
        West,
        East,
        North_West,
        North_East,
        South_West,
        South_East
    }

    struct QueensAttack{
        public Directions Direction;
        public int ObstaclePosition;
        public int MoveCount;
    }

    public static void Main(String[] args)
    {
        //string cont = "e";
        //       do
        //       {

        var stime = DateTime.Now;
        string[] tokens_n = ReadLineFromFile().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] tokens_rQueen = ReadLineFromFile().Split(' ');
        int rQueen = Convert.ToInt32(tokens_rQueen[0]);
        int cQueen = Convert.ToInt32(tokens_rQueen[1]);

        List<QueensAttack> queensAttack = new List<QueensAttack>();

        AddDirection(Directions.West, queensAttack, cQueen - 1);
        AddDirection(Directions.East, queensAttack, n - cQueen);
        AddDirection(Directions.North, queensAttack, n - rQueen);
        AddDirection(Directions.South, queensAttack, rQueen - 1);
        AddDirection(Directions.South_West, queensAttack, Math.Min(queensAttack.First(x => x.Direction == Directions.South).MoveCount, queensAttack.First(x => x.Direction == Directions.West).MoveCount));
        AddDirection(Directions.North_West, queensAttack, Math.Min(queensAttack.First(x => x.Direction == Directions.North).MoveCount, queensAttack.First(x => x.Direction == Directions.West).MoveCount));
        AddDirection(Directions.South_East, queensAttack, Math.Min(queensAttack.First(x => x.Direction == Directions.South).MoveCount, queensAttack.First(x => x.Direction == Directions.East).MoveCount));
        AddDirection(Directions.North_East, queensAttack, Math.Min(queensAttack.First(x => x.Direction == Directions.North).MoveCount, queensAttack.First(x => x.Direction == Directions.East).MoveCount));

        QueensAttack temp = new QueensAttack();
        int index = -1;
        for (int a0 = 0; a0 < k; a0++)
        {
            string[] tokens_rObstacle = ReadLineFromFile().Split(' ');
            int rObstacle = Convert.ToInt32(tokens_rObstacle[0]);
            int cObstacle = Convert.ToInt32(tokens_rObstacle[1]);
            int x = Math.Abs(cObstacle - cQueen);
            int y = Math.Abs(rObstacle - rQueen);

            if (rQueen == rObstacle)
            {
                if (cObstacle < cQueen)
                {
                    temp = queensAttack.First(item => item.Direction == Directions.West);
                    index = queensAttack.IndexOf(temp);
                    if (cObstacle > temp.ObstaclePosition)
                    {
                        // if obstacle is the right of the prev. obstacle, change moveCount and obstacle position
                        // start obstacle position -1, for that reason all obstacle position bigger then this.
                        temp.MoveCount = cQueen - (cObstacle + 1);
                        temp.ObstaclePosition = cObstacle;
                        queensAttack[index] = temp;
                    }
                }
                else
                {

                    temp = queensAttack.First(item => item.Direction == Directions.East);
                    index = queensAttack.IndexOf(temp);
                    if (temp.ObstaclePosition == -1 || cObstacle < temp.ObstaclePosition)
                    {
                        // if obstacle is the right of the prev. obstacle or Obstacle Position is default, change moveCount and obstacle position
                        temp.MoveCount = cObstacle - (cQueen + 1);
                        temp.ObstaclePosition = cObstacle;
                        queensAttack[index] = temp;
                    }
                }
            }
            else if (cQueen == cObstacle)
            {

                if (rObstacle < rQueen)
                {
                    temp = queensAttack.First(item => item.Direction == Directions.South);
                    index = queensAttack.IndexOf(temp);
                    if (rObstacle > temp.ObstaclePosition)
                    {
                        // if obstacle is the upper of the prev. obstacle, change moveCount and obstacle position
                        // start obstacle position -1, for that reason all obstacle position bigger then this. 
                        temp.MoveCount = rQueen - (rObstacle + 1);
                        temp.ObstaclePosition = rObstacle;
                        queensAttack[index] = temp;
                    }
                }
                else
                {

                    temp = queensAttack.First(item => item.Direction == Directions.North);
                    index = queensAttack.IndexOf(temp);
                    if (temp.ObstaclePosition == -1 || rObstacle < temp.ObstaclePosition)
                    {
                        // if obstacle is the above of the prev. obstacle or Obstacle Position is default, change moveCount and obstacle position
                        temp.MoveCount = rObstacle - (rQueen + 1);
                        temp.ObstaclePosition = rObstacle;
                        queensAttack[index] = temp;
                    }
                }
            }
            if (x == y)
            {
                if ((cObstacle < cQueen) && (rObstacle < rQueen))
                {
                    DefineDiagonal(Directions.South_West, queensAttack, x);
                }
                else if ((cObstacle < cQueen) && (rObstacle > rQueen))
                {
                    DefineDiagonal(Directions.North_West, queensAttack, x);
                }
                else if ((cObstacle > cQueen) && (rObstacle < rQueen))
                {
                    DefineDiagonal(Directions.South_East, queensAttack, x);
                }
                else if ((cObstacle > cQueen) && (rObstacle > rQueen))
                {
                    DefineDiagonal(Directions.North_East, queensAttack, x);
                }

            }
        }

        int sum = 0;

        foreach (var items in queensAttack)
        {
            sum += items.MoveCount;
        }

        Console.WriteLine(sum);
        var performance = DateTime.Now - stime;
        Console.WriteLine(performance.Ticks);
        Console.ReadLine();
        //cont = Console.ReadLine();

        //        }while (cont != "h") ;

    }

    private static void AddDirection(Directions direction, List<QueensAttack> queensAttack, int moveCount)
    {
        queensAttack.Add(new QueensAttack()
        {
            Direction = direction,
            ObstaclePosition = -1,
            MoveCount = moveCount
        });
    }

    private static void DefineDiagonal(Directions direction, List<QueensAttack> queensAttack, int diagonalPosition)
    {
        var temp = queensAttack.First(item => item.Direction == direction);
        var index = queensAttack.IndexOf(temp);
        if ((diagonalPosition - 1) < temp.MoveCount)
        {
            // if obstacle is the above of the prev. obstacle or Obstacle Position is default, change moveCount and obstacle position
            temp.MoveCount = diagonalPosition - 1;
            temp.ObstaclePosition = diagonalPosition;
            queensAttack[index] = temp;
        }
    }

    static FileStream file;
    static StreamReader sr;
    static string fileName = @"F:\C#\Hackerrank\Queen's Attack II\test18.txt";
    private static string ReadLineFromFile()
    {
        if (file == null)
        {
            file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            sr = new StreamReader(file);
        }

        var returnValue = sr.ReadLine();
        Console.WriteLine(returnValue);
        return returnValue;
    }
}
