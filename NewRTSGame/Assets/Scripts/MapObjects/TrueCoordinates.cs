using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueCoordinates : MonoBehaviour
{
    [SerializeField] private float x;
    public float X { get { return x; } set { x = value; } }

    [SerializeField] private float y;
    public float Y { get { return y; } set { y = value; } }

    public override bool Equals(System.Object obj)
    {
        if (obj == null)
            return false;
        WorldCoordinates c = obj as WorldCoordinates;
        if ((System.Object)c == null)
            return false;

        if(!Mathf.Approximately(X,c.X) || !Mathf.Approximately(Y,c.Y))
        {
            return false;
        }

        return true;
    }
    public bool Equals(WorldCoordinates c)
    {
        if ((object)c == null)
            return false;
        if (!Mathf.Approximately(X,c.X) || Mathf.Approximately(Y,c.Y))
        {
            return false;
        }

        return true;
    }
}
