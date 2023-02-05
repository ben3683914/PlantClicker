using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potatoe : MonoBehaviour
{
    Tile Tile;

    private void Start()
    {
        Tile = GetComponent<Tile>();
        Tile.Type = TilesManager.TileType.Potatoe;
        StartCoroutine(Age());
    }

    public void Die()
    {
        var grid = GameManager.Instance.MapManager.grid;
        GameManager.Instance.MapManager.PlantsMap.RemoveTile(grid.GetCellAtWorldPosition(transform.position));
    }

    private IEnumerator Age()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Aged out...");
        Die();
    }
}
