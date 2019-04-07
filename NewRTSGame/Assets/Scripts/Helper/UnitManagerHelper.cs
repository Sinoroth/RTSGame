using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public static class UnitManagerHelper
    {
        private  static TrueCoordinates clickedPosition = new TrueCoordinates();

        internal static void GetClickedLocation(float x, float y)
        {
            clickedPosition.X = x;
            clickedPosition.Y = y;
        }

        internal static float GetClickedObjectX()
        {
            return clickedPosition.X;
        }

        internal static float GetClickedObjectY()
        {
            return clickedPosition.Y;
        }
    }
}