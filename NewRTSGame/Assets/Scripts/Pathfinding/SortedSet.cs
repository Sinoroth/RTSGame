using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortedSet<U>
{
    private List<U> values;
    private List<double> keys;

    public SortedSet()
    {
        keys = new List<double>();
        values = new List<U>();
    }

    public SortedSet(double first, U second)
    {
        keys = new List<double>();
        values = new List<U>();
    }


    public Pair<double, U> GetFirstElement() {
        Pair<double, U> smallestValue = new Pair<double, U>();

        int index = 0,minIndex=0;
        double min = keys[0];
        foreach(var key in keys) {
            if (min>key) {
                min = key;
                minIndex = index;
            }
            ++index;
        }
        smallestValue.SetValues(keys[minIndex], values[minIndex]);
        return smallestValue; 
    }


    public void Add(double key, U value)
    {
        if (ElementExists(value))
        {
            UpdateValue(key, value);
        }
        else
        {
            keys.Add(key);
            values.Add(value);
        }
    }

    public void RemoveElement(double key, U value)
    {
        int index = 0;
        foreach(var listKey in keys)
        {
            if(listKey.Equals(key))
            {
                if(values[index].Equals(value))
                {
                    values.Remove(values[index]);
                    keys.Remove(listKey);
                    break;
                }
            }
            index++;
        }
    }

    public bool ElementExists(U value)
    {
        return values.Contains(value);
    }

    public void UpdateValue(double value, U key)
    {
        int index = 0;
        foreach (var listKey in values)
        {
            if (listKey.Equals(key)) {
                keys[index] = value;
                break;
            }
       
            index++;
        }
    }

    internal bool IsNotEmpty()
    {
        if (values.Count == 0) return false;
        else return true;
    }
}
