using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PotatoeGrowStage3 : PotatoeState
{
    public float growTime;
    public PotatoeGrowStage3(Potatoe potatoe) : base(potatoe)
    {
        growTime = Random.Range(0.5f, 1.5f);
        potatoe.spriteRenderer.sprite = potatoe.GrowthSprites[1];
    }

    public override IEnumerator Start()
    {
        Debug.Log("PotatoeGrowStage3...waiting...");
        yield return new WaitForSeconds(3.0f);
        potatoe.SetState(new PotatoeGrowStageHarvestable(potatoe));
    }
}