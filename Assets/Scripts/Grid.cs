using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {

    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int y = 0; y < gridArray.GetLength(1); y++) {
            for (int x = 0; x < gridArray.GetLength(0); x++) {
                debugTextArray[x, y] = CreateWorldText(gridArray[x, y].ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
    }

    public static TextMesh CreateWorldText(string text, Vector3 localPosition = default(Vector3)) {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.text = text;
        textMesh.fontSize = 30;
        textMesh.color = Color.white;
        return textMesh;
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y, 0) * cellSize;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }

    public void SetValue(int x, int y, int value) {
        if (x >= 0 && x < width && y >= 0 && y < height) {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = value.ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x >= 0 && x < width && y >= 0 && y < height) {
            return gridArray[x, y];
        }
        return -1;
    }

    public int GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
