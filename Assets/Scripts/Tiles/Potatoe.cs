using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potatoe : MonoBehaviour
{
    public Sprite[] GrowthSprites;
    public SpriteRenderer spriteRenderer;

    Tile Tile;
    private PotatoeState currentState;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Tile = GetComponent<Tile>();
        Tile.Type = TilesManager.TileType.Potatoe;
        SetState(new PotatoeBeginState(this));
    }

    public void SetState(PotatoeState state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }
}
