using System;
using System.Collections.Generic;

namespace Triangles
{
    public struct Point
    {
        public double X { readonly get; set; }
        public double Y { readonly get; set; }
    }


    public class Triangle
    {
        public Point[] Points { get; set; }

        public Triangle()
        {
            Points = new Point[3];
        }

        public Triangle(Point first, Point second, Point third)
        {
            Points = new Point[3] { first, second, third };
        }

        public override string? ToString()
        {
            return $"{Points[0].ToString()}, {Points[1].ToString()}, {Points[2].ToString()}";
        }

    }

    public static class TriangleOperations
    {
        private static double GetLength(Point first, Point second)
        {
            return Math.Sqrt(
                Math.Pow(first.X - second.X, 2)
                +
                Math.Pow(first.Y - second.Y, 2)
                ); // c^2 = (xA − xB)^2 + (yA − yB)^2
        }

        private static double GetAngle(Point a, Point b, Point c)
        {
            double x1 = a.X - b.X, x2 = c.X - b.X;
            double y1 = a.Y - b.Y, y2 = c.Y - b.Y;

            double d1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double d2 = Math.Sqrt(x2 * x2 + y2 * y2);

            return (180 / Math.PI) * Math.Acos((x1 * x2 + y1 * y2) / (d1 * d2));
        }

        private static List<double> GetSides(Triangle triangle)
        {
            var points = triangle.Points;

            List<double> sides = new List<double>
                {
                    GetLength(points[0], points[1]),
                    GetLength(points[1], points[2]),
                    GetLength(points[0], points[2])
                };
            return sides;
        }

        private static List<double> GetAngles(Triangle triangle)
        {
            var points = triangle.Points;

            var angles = new List<double>
                {
                   Math.Abs( GetAngle(points[0], points[1], points[2]) ),
                   Math.Abs( GetAngle(points[1], points[2], points[0]) ),
                   Math.Abs( GetAngle(points[2], points[0], points[1]) ),
                };
            return angles;
        }

        public static List<Triangle> GetIsosceles(List<Triangle> triangles)
        {
            var result = new List<Triangle>();

            foreach (var triangle in triangles)
            {
                var sides = GetSides(triangle);

                if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
                {
                    result.Add(triangle);
                }
            }

            return result;
        }

        public static List<Triangle> GetEquilateral(List<Triangle> triangles)
        {
            var result = new List<Triangle>();

            foreach (var triangle in triangles)
            {
                var sides = GetSides(triangle);

                if (sides[0] == sides[1] && sides[1] == sides[2])
                {
                    result.Add(triangle);
                }
            }

            return result;
        }

        public static List<Triangle> GetRectengular(List<Triangle> triangles)
        {
            var result = new List<Triangle>();

            foreach (var triangle in triangles)
            {
                var angles = GetAngles(triangle);

                foreach (var angle in angles)
                {
                    if (angle == 90)
                        result.Add(triangle);
                }
            }

            return result;
        }

        public static List<Triangle> GetObtuse(List<Triangle> triangles, decimal required_area)
        {
            var result = new List<Triangle>();

            foreach (var triangle in triangles)
            {
                var angles = GetAngles(triangle);
                var sides = GetSides(triangle);

                var p = (sides[0] + sides[1] + sides[2]) / 2;
                decimal area = (decimal)Math.Sqrt(
                    p * (p - sides[0]) * (p - sides[1]) * (p - sides[2])
                    );

                foreach (var angle in angles)
                {
                    if (angle > 90 && required_area <= area)
                        result.Add(triangle);
                }
            }
            return result;
        }

    }
}
