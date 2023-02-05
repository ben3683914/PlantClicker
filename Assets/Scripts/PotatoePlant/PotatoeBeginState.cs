using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PotatoeBeginState : PotatoeState
{
    private float growTime;
    public PotatoeBeginState(Potatoe potatoe) : base(potatoe)
    {
        growTime = Random.Range(3f, 5f);
    }

    public override IEnumerator Start()
    {
        Debug.Log("potatoebeginstate...waiting...");
        yield return new WaitForSeconds(growTime);
        potatoe.SetState(new PotatoeGrowStage2(potatoe));
    }
}