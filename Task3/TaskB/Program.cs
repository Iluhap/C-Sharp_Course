using System;
using System.Collections.Generic;
using Triangles;

/*
 * Треугольники. В сущностях (типах) хранятся координаты вершин треугольников на плоскости.
 * Вывести все равнобедренные треугольники.
 * Вывести все равносторонние треугольники. 
 * Вывести все прямоугольные треугольники. 
 * Вывести все тупоугольные треугольники с площадью больше заданной.
 */
namespace TaskB
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangles = new List<Triangle>
            {
                new Triangle
                {
                    Points = new Point[]
                    {
                        new Point { X = 0, Y = 0 },
                        new Point { X = 10, Y = 10 },
                        new Point { X = 0, Y = 10 }
                    }
                },

                new Triangle
                {
                    Points = new Point[]
                    {
                        new Point { X = 4, Y = 0 },
                        new Point { X = 0, Y = 0},
                        new Point { X = -3, Y = 2}
                    }
                },

                new Triangle
                {
                    Points = new Point[]
                    {
                        new Point { X = 0, Y = 1 },
                        new Point { X = 0.707, Y = -0.707 },
                        new Point { X = -0.707, Y = -0.707 }
                    }
                },

                new Triangle
                {
                    Points = new Point[]
                    {
                        new Point { X = 0, Y = 0 },
                        new Point { X = 2, Y = 2 },
                        new Point { X = 0, Y = 2 }
                    }
                },
            };

            List<Triangle> processed;

            processed = TriangleOperations.GetEquilateral(triangles);
            processed = TriangleOperations.GetIsosceles(triangles);
            processed = TriangleOperations.GetObtuse(triangles, 0m);
            processed = TriangleOperations.GetRectengular(triangles);
        }
    }
}
