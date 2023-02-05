using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PotatoeGrowStage2 : PotatoeState
{
    private float growTime;
    public PotatoeGrowStage2(Potatoe potatoe) : base(potatoe)
    {
        growTime = Random.Range(2f, 3f);
        potatoe.spriteRenderer.sprite = potatoe.GrowthSprites[0];
    }

    public override IEnumerator Start()
    {
        Debug.Log("PotatoeGrowStage2...waiting...");
        yield return new WaitForSeconds(growTime);
        potatoe.SetState(new PotatoeGrowStage3(potatoe));
    }
}