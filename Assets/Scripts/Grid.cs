using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Events;
using System;

public class Grid
{
    public bool ShowDebug = false;
    public UnityEvent<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private int[,] gridArray;
    private Vector3 originPosition;
    private TextMesh[,] debugTextArray;
    private float cellSize;

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        if (ShowDebug)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    UtilsClass.CreateWorldText($"{x},{y}", null, GetPlaceableCellWorldPosition(x, y), 20, Color.white, TextAnchor.MiddleCenter);
                    //debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x,y) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            }

            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        }        
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public Vector3 GetPlaceableCellWorldPosition(int x, int y)
    {
        return GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f;
    }
    public Vector3 GetPlaceableCellWorldPosition(Vector2Int worldPosition)
    {
        return GetPlaceableCellWorldPosition(worldPosition.x, worldPosition.y);
    }

    public  Vector2Int GetCellAtWorldPosition(Vector3 worldPosition)
    {
        return new Vector2Int()
        {
            x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize),
            y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize)
        };
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    private void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
            if(OnGridValueChanged != null) OnGridValueChanged.Invoke(new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    private void SetValue(Vector3 worldPosition, int value)
    {
        var coords = GetCellAtWorldPosition(worldPosition);
        SetValue(coords.x, coords.y, value);
    }

    private int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            return gridArray[x, y];
        else
            return 0;
    }

    private int GetValue(Vector3 worldPosition)
    {
        var coords = GetCellAtWorldPosition(worldPosition);

        return GetValue(coords.x, coords.y);
    }
}
