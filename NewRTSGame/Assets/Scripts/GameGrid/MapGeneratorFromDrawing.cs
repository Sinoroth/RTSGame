using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapGeneratorFromDrawing{

    [SerializeField] private ColorToPrefab[] colorToPrefabs;

    public void GenerateMap(GameGrid grid, Texture2D map, GameGridManager manager)
    {
        for (int widthIndex = 0; widthIndex < map.width; ++widthIndex)
        {
            for(int heightIndex = 0; heightIndex < map.height; ++heightIndex)
            {
                GenerateObjectForPixel(grid, map,widthIndex, heightIndex,manager);
            }
        }
    }

    private void GenerateObjectForPixel(GameGrid grid, Texture2D map,int widthIndex, int heightIndex,GameGridManager manager)
    {
        Color pixelColor = map.GetPixel(widthIndex, heightIndex);

        if(pixelColor.a == 0)
        {
            return;
        }

        foreach (var colorPrefab in colorToPrefabs)
        {
            if(colorPrefab.IsColor(pixelColor))
            {
                GameObject generatedObject = GameObject.Instantiate(colorPrefab.ReturnGameObject());

                GridSpace newGridSpace = new GridSpace(widthIndex, heightIndex, generatedObject,generatedObject.GetComponent<WorldObject>().BlocksSquare());

                generatedObject.GetComponent<WorldObject>().SetCoordinates(widthIndex,heightIndex);

                generatedObject.transform.localPosition = new Vector3(widthIndex, heightIndex, -0.1f);
                grid.AddObjectToGrid(generatedObject);
                grid.AddGridSpacetoArray(newGridSpace,widthIndex,heightIndex);

                generatedObject.GetComponent<GridElementClickEvents>().SetGrid(widthIndex, heightIndex);
            }
        }
    }

    internal void GenerateMap(GameObject testobject, GameGrid grid, Texture2D map, GameGridManager manager)
    {
        for (int widthIndex = 0; widthIndex < map.width; ++widthIndex)
        {
            for (int heightIndex = 0; heightIndex < map.height; ++heightIndex)
            {
                if(widthIndex == 3 && heightIndex == 3)
                {
                    GameObject generatedObject = GameObject.Instantiate(testobject);

                    GridSpace newGridSpace = new GridSpace(widthIndex, heightIndex, generatedObject, generatedObject.GetComponent<WorldObject>().BlocksSquare());

                    generatedObject.transform.position = new Vector3(widthIndex, heightIndex, -0.1f);
                    grid.AddObjectToGrid(generatedObject);
                    grid.AddGridSpacetoArray(newGridSpace, widthIndex, heightIndex);
                    generatedObject.SetActive(true);
                    generatedObject.GetComponent<TestUnit>().Initialize(map.width,map.height,widthIndex, heightIndex);
                }
                GenerateObjectForPixel(grid, map, widthIndex, heightIndex, manager);
            }
        }
    }
}
