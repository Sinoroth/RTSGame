using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{

    public static class GameResourceManager
    {

        public static float MinCameraHeight
        {
            get { return 0; }
        }

        public static float MaxCameraHeight
        {
            get { return 40; }
        }

        public static float ScrollSpeed
        {
            get { return 10.0f; }
        }

        public enum ResourceTypes
        {
            Food = 0,
            Wood = 1,
            Gold = 2,
            Stone = 3
        }

        public static int[,] ResourceValues = new int[4, 2] { { MaxFoodValue, MinFoodValue } ,{MaxWoodValue,  MinWoodValue  },
                                                              { MaxGoldValue, MinGoldValue } ,{MaxStoneValue, MinStoneValue }};

        #region ResourceValues
        public static int MaxFoodValue { get { return 1000; } }
        public static int MinFoodValue { get { return 0; } }
        public static int MaxWoodValue { get { return 1000; } }
        public static int MinWoodValue { get { return 0; } }
        public static int MaxGoldValue { get { return 1000; } }
        public static int MinGoldValue { get { return 0; } }
        public static int MaxStoneValue { get { return 1000; } }
        public static int MinStoneValue { get { return 0; } }
        #endregion
    }

}