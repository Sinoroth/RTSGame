using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public static class PathFindingHeuristics
    {

        public enum HeuristicMethod
        {
            ManhattanDistance,
            DiagonalDistance,
            EuclidianDistance
        };

        public static float HeuristicCalculation(int currentX, int currentY, int destinationX, int destinationY, HeuristicMethod method)
        {
            if (method == HeuristicMethod.ManhattanDistance)
            {
                return ManhattanHeuristic(currentX, currentY, destinationX, destinationY);
            }
            else if (method == HeuristicMethod.DiagonalDistance)
            {
                return DiagonalHeuristic(currentX, currentY, destinationX, destinationY);
            }
            else if (method == HeuristicMethod.EuclidianDistance)
            {
                return EuclidianHeuristic(currentX, currentY, destinationX, destinationY);
            }
            else return 0;
        }

        private static float ManhattanHeuristic(int currentX, int currentY, int destinationX, int destinationY)
        {
            return Mathf.Abs(currentX - destinationX) + Mathf.Abs(currentY - destinationY);
        }

        private static float DiagonalHeuristic(int currentX, int currentY, int destinationX, int destinationY)
        {
            return Mathf.Max(Mathf.Abs(currentX - destinationX), Mathf.Abs(currentY - destinationY));
        }

        private static float EuclidianHeuristic(int currentX, int currentY, int destinationX, int destinationY)
        {
            return (float)Mathf.Sqrt(Mathf.Pow((currentX - destinationX), 2) + Mathf.Pow((currentY - destinationY), 2));
        }
    }
}