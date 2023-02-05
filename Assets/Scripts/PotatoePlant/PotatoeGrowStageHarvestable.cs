using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PotatoeGrowStageHarvestable : PotatoeState
{
    public PotatoeGrowStageHarvestable(Potatoe potatoe) : base(potatoe)
    {
        potatoe.spriteRenderer.color = new Color(1f,0.85f,0.80f, 1f);
    }
}