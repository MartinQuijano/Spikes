using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustObjectToGrid : MonoBehaviour
{
    void Start()
    {
        Grid grid = transform.root.GetComponent<Grid>();
        Vector3Int cellPosition = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterWorld(cellPosition);
    }
}
