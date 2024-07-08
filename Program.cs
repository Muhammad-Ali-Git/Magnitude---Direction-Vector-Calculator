using System;
using System.Collections.Generic;

class DirectionDistance
{
    public string Direction { get; set; }
    public double Distance { get; set; }

    public DirectionDistance(string direction, double distance)
    {
        Direction = direction;
        Distance = distance;
    }
}

class Ali
{
    public static void Main()
    {
        Console.WriteLine("This program calculates the final vector from the given directions and distances input by user.");
        Console.WriteLine("\n-----------------------------------------------------\n");

        List<DirectionDistance> movements = new List<DirectionDistance>();

        Console.WriteLine("How many directions will you input?");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            START:
            Console.WriteLine("Enter direction {0} (north, south, east, west): ", i + 1);
            string direction = Console.ReadLine().ToLower();

            if (direction != "east" && direction != "west" && direction != "north" && direction != "south")
            {
                Console.WriteLine("Wrong Directions Entered! Please Try Again!");
                Console.WriteLine("\n-----------------------------------------------------\n");
                goto START;
            }
            else
            {
                Console.WriteLine("Enter distance in meters for direction {0}: ", i + 1);
            }

            double distance = double.Parse(Console.ReadLine());
            movements.Add(new DirectionDistance(direction, distance));
        }

        double totalX = 0;
        double totalY = 0;

        foreach (var movement in movements)
        {
            switch (movement.Direction)
            {
                case "north":
                    totalY += movement.Distance;
                    break;
                case "south":
                    totalY -= movement.Distance;
                    break;
                case "east":
                    totalX += movement.Distance;
                    break;
                case "west":
                    totalX -= movement.Distance;
                    break;
                default:
                    Console.WriteLine("Invalid direction entered.");
                    break;
            }
        }

        double magnitude = Math.Sqrt(totalX * totalX + totalY * totalY);
        string finalDirection = CalculateDirection(totalX, totalY);

        double angleInRadians = Math.Atan2(totalY, totalX);
        double angleInDegrees = angleInRadians * (180.0 / Math.PI);

        if (angleInDegrees < 0)
        {
            angleInDegrees += 360.0;
        }

        Console.WriteLine("Final Direction: {0}", finalDirection);
        Console.WriteLine("Final Magnitude: {0}m", magnitude);
        Console.WriteLine("Final Angle: {0} degree", angleInDegrees);
    }

    public static string CalculateDirection(double x, double y)
    {
        if (x == 0 && y == 0)
            return "No movement";

        if (x == 0)
            return y > 0 ? "North" : "South";

        if (y == 0)
            return x > 0 ? "East" : "West";

        string horizontal = x > 0 ? "East" : "West";
        string vertical = y > 0 ? "North" : "South";

        return vertical + "-" + horizontal;
    }
}