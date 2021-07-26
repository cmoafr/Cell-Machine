using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    private Grid grid;

    void Start() {
        grid = new Grid(20, 10, 10f);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grid.SetValue(pos, grid.GetValue(pos)+1);
        }
    }
}
