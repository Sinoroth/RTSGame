using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathFindingUnitLogic
{
    private PathFinding pathFinding;

    [SerializeField] private WorldCoordinates currentCoordinates;
    private WorldCoordinates destinationCoordinates;
    private WorldCoordinates nextCoordinates;

    private TrueCoordinates currentTrueCoordinates;
    private TrueCoordinates destinationTrueCoordinates;
    private TrueCoordinates nextTrueCoordinates;

    private Stack<Pair<int, int>> path = new Stack<Pair<int, int>>();
    private bool isMoving = false;
    Pair<int, int> point;
    Vector2 current, next;


    public PathFindingUnitLogic()
    {
        pathFinding = new PathFinding();

        destinationCoordinates = new WorldCoordinates();
        currentCoordinates = new WorldCoordinates();
        nextCoordinates = new WorldCoordinates();

        currentTrueCoordinates = new TrueCoordinates();
        destinationTrueCoordinates = new TrueCoordinates();
        nextTrueCoordinates = new TrueCoordinates();
    }

    internal void GetPath(int destinationX,int destinationY)
    {
        destinationCoordinates.X = destinationX;
        destinationCoordinates.Y = destinationY;
        Debug.Log("Initializing currentCoordinates" + currentCoordinates.X + " " + currentCoordinates.Y);
        Debug.Log("Initializing Destination " + destinationCoordinates.X + " " + destinationCoordinates.Y);
        path = pathFinding.GetPath(currentCoordinates, destinationCoordinates);
    }

    internal void SetStart(int x, int y)
    {
        currentCoordinates.X = x;
        currentCoordinates.Y = y;
    }
    private int count = 0;
    internal void MoveUnit(GameObject unit, float movementSpeed)
    {
        //if (count == 1) return;
        if (isMoving == false) return;
        
        if (destinationCoordinates.Equals(currentCoordinates) || path.Count < 0)
        {
            ++count;
            Debug.Log("Final currentCoordinates" + currentCoordinates.X + " " + currentCoordinates.Y);
            Debug.Log("Destination " + destinationCoordinates.X + " " + destinationCoordinates.Y);
            unit.transform.position = new Vector2(destinationCoordinates.X, destinationCoordinates.Y);
            isMoving = false;

            return;
        }
            if (nextCoordinates.X < currentCoordinates.X)
                currentCoordinates.X -= 1;
            else if (nextCoordinates.X > currentCoordinates.X)
                currentCoordinates.X += 1;
        
            if (nextCoordinates.Y < currentCoordinates.Y)
                currentCoordinates.Y -= 1;
            else if (nextCoordinates.Y > currentCoordinates.Y)
                currentCoordinates.Y += 1;
       
        unit.transform.position = new Vector2(currentCoordinates.X, currentCoordinates.Y);

        if ((nextCoordinates.Equals(currentCoordinates)))
        {
            if (path.Count != 0)
            {
                point = path.Pop();
                nextCoordinates.X = point.First;
                nextCoordinates.Y = point.Second;
            }
        }
        /*
        if (destinationTrueCoordinates.Equals(currentTrueCoordinates) || path.Count <= 0)
        {
            Debug.Log("Destination is " + destinationTrueCoordinates.X + " " + destinationTrueCoordinates.Y);
            unit.transform.position = new Vector2(currentTrueCoordinates.X, currentTrueCoordinates.Y);
            Debug.Log("Test");
            currentCoordinates = destinationCoordinates;
            Debug.Log("TesTestt");
            isMoving = false;
            Debug.Log("TesTetetett");

            return;
        }
        
        if (!Mathf.Approximately(currentTrueCoordinates.X, nextTrueCoordinates.X))
        {
            if (nextTrueCoordinates.X < currentTrueCoordinates.X)
                currentTrueCoordinates.X -= 1;
            else if (nextTrueCoordinates.X > currentTrueCoordinates.X)
                currentTrueCoordinates.X += 1;
        }

        if (!Mathf.Approximately(currentTrueCoordinates.Y, nextTrueCoordinates.Y))
        {
            if (nextTrueCoordinates.Y < currentTrueCoordinates.Y)
                currentTrueCoordinates.Y -= 1;
            else if (nextTrueCoordinates.Y > currentTrueCoordinates.Y)
                currentTrueCoordinates.Y += 1;
        }
        unit.transform.position = new Vector2(currentTrueCoordinates.X, currentTrueCoordinates.Y);

        if ((nextTrueCoordinates.Equals(currentTrueCoordinates))){
            point = path.Pop();
            nextTrueCoordinates.X = point.First;
            nextTrueCoordinates.Y = point.Second;
        }*/
        /*
        if (current.Equals(next))
        {
            point = path.Pop();
            nextCoordinates.X = point.First;
            nextCoordinates.Y = point.Second;
        }
        Debug.Log("test");
        //current = new Vector2(currentCoordinates.X, currentCoordinates.Y);
        next = new Vector2(nextCoordinates.X, nextCoordinates.Y);

        var heading = next - current;
        var distance = heading.magnitude;
        var direction = heading / distance;

        current += direction * Time.deltaTime * movementSpeed;
        unit.transform.position = new Vector2(current.x, current.y);*/
    }

    internal void MoveUnit(GameObject unit, int x, int y, float movementSpeed)
    {
        GetPath(x, y);
        Debug.Log("Destination is " + x + " " + y);
        WorldCoordinates tempCoordinates = new WorldCoordinates();
        Pair<int, int> point;

        isMoving = true;

        point = path.Pop();
        nextTrueCoordinates.X = point.First;
        nextTrueCoordinates.Y = point.Second;
        nextCoordinates.X = point.First;
        nextCoordinates.Y = point.Second;
        destinationTrueCoordinates.X = x;
        destinationTrueCoordinates.Y = y;
        return;

        while (!destinationCoordinates.Equals(currentCoordinates) && path.Count > 0)
        {
            point = path.Pop();
            tempCoordinates.X = point.First;
            tempCoordinates.Y = point.Second;

            Vector2 current = new Vector2(currentCoordinates.X,currentCoordinates.Y);
            Vector2 next = new Vector2(tempCoordinates.X,tempCoordinates.Y);

            var heading = next - current;
            var distance = heading.magnitude;
            var direction = heading / distance;
            int xx = 0;

            while (current != next)
            {
                if (xx == 1000) break;
                ++xx;
                Debug.Log("current is " + current.x + " " + current.y);
                current += direction * Time.deltaTime * movementSpeed;
                unit.transform.position = new Vector2(current.x, current.y);
            }
            /*
            while (!(tempCoordinates.Equals(currentCoordinates)))
            {
                    if (tempCoordinates.X < currentCoordinates.X)
                        currentCoordinates.X -= 1;
                    else if (tempCoordinates.X > currentCoordinates.X)
                        currentCoordinates.X += 1;

                    if (tempCoordinates.Y < currentCoordinates.Y)
                        currentCoordinates.Y -= 1;
                    else if (tempCoordinates.Y > currentCoordinates.Y)
                        currentCoordinates.Y += 1;

            }
            */
        }
    }
}
