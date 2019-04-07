using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public static class GeneralManagerFunctions
    {
        public static void SetSceneManager(SceneManager manager)
        {
            manager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        }
    }
}
