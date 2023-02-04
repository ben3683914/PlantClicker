using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PlayUI : UIComponent
{
    public TextMeshProUGUI seedCount;

    private void Start()
    {
        GameManager.Instance.SeedManager.OnScoreChanged.AddListener(OnSeedCountChanged);
        OnSeedCountChanged();
    }

    void OnSeedCountChanged()
    {
        var seeds = GameManager.Instance.SeedManager.GetSeeds();
        seedCount.text = $"Seeds: { seeds }";
    }
}
