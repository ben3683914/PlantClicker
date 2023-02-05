using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeedManager : MonoBehaviour
{
    public UnityEvent OnScoreChanged;
    private int seeds = 0;

    private void Awake()
    {
        if (OnScoreChanged == null)
            OnScoreChanged = new UnityEvent();
    }

    public void Start()
    {
        AddSeeds(2); 
    }

    public void AddSeeds(int amount = 1)
    {
        seeds += amount;
        OnScoreChanged.Invoke();
    }

    public int GetSeeds()
    {
        return seeds;
    }
}
