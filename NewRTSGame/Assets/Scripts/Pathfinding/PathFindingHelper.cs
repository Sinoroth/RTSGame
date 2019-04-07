using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public static class PathFindingHelper
    {
        public static int maxValue = 9999;

        public static int neighborLength = 8;

        public static int maxHeight, maxWidth;

        public static GameGrid grid;

        public static int[,] Neighbors = new int[8,2]{ 
        {-1,0},
        {1,0},
        {0,1},
        {0,-1},
        {-1,1},
        {-1,-1},
        {1,1},
        {1,-1}
        };

        public static void SetGameGrid(GameGrid gameGrid)
        {
            grid = gameGrid;
        }

        private static RTS.PathFindingHeuristics.HeuristicMethod method = RTS.PathFindingHeuristics.HeuristicMethod.EuclidianDistance;

        public static float CalculateHeuristic(int currentX, int currentY, int destinationX, int destinationY)
        {
            return RTS.PathFindingHeuristics.HeuristicCalculation(currentX, currentY, destinationX, destinationY, method);
        }

        public static bool IsSearchValid(int currentX, int currentY, int destinationX, int destinationY)
        {
            if (IsStartSameAsDestination(currentX, currentY, destinationX, destinationY))
            {
                return true;
            }
            if(AreDimensionsOutofBounds(currentX, currentY, destinationX, destinationY))
            {
                return false;
            }

            return true;
        }

        private static bool AreDimensionsOutofBounds(int currentX, int currentY, int destinationX, int destinationY)
        {
            if (currentX < 0 || currentX >= maxWidth) return true;
            if (currentY < 0 || currentY >= maxHeight) return true;
            if (destinationX < 0 || destinationX >= maxWidth) return true;
            if (destinationY < 0 || destinationY >= maxHeight) return true;
            return false;
        }

        public static void SetMaxDimensions(int maxwidth, int maxheight)
        {
            maxWidth = maxwidth;
            maxHeight = maxheight;
        }

        private static bool IsStartSameAsDestination(int currentX, int currentY, int destinationX, int destinationY)
        {
            if(currentX == destinationX && currentY == destinationY)
            {
                return true;
            }
            return false;
        }

        public static bool HasDestinationBeenReached(int currentX, int currentY, int destinationX, int destinationY)
        {
            return IsStartSameAsDestination(currentX, currentY, destinationX, destinationY);
        }

        internal static bool IsCellFree(GameGrid grid, int v, int j)
        {
            if (grid.IsCellFree(v, j))
            {
                return true;
            }
            else return false;
        }

        public static double CaculateHValue(int i,int j,int destinationX, int destinationY)
        {
            return ((double)Mathf.Sqrt((i - destinationX) * (i - destinationX)
                          + (j - destinationY) * (j - destinationY)));
        }
    }
}