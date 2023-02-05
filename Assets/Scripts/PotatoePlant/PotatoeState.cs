using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class PotatoeState
{
    protected readonly Potatoe potatoe;

    public PotatoeState(Potatoe potatoe)
    {
        this.potatoe = potatoe;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}