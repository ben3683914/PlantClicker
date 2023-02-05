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
    public TextMeshProUGUI levelMatrixText;

    public int level = 2;

    private void Start()
    {
        GameManager.Instance.SeedManager.OnScoreChanged.AddListener(OnSeedCountChanged);

        OnSeedCountChanged();
        OnLevelChanged();
    }

    void OnSeedCountChanged()
    {
        var seeds = GameManager.Instance.SeedManager.GetSeeds();
        seedCount.text = $"Seeds: {seeds}";
    }

    void OnLevelChanged()
    {
        levelMatrixText.text = $"{level}x{level}";
    }

    public void OnPlantToolClick()
    {
        Debug.Log("planter tool selected");
    }

    public void OnHarvestToolClick()
    {
        Debug.Log("harvest tool selected");
    }

    public void OnPointerEnter()
    {
        Debug.Log("pointer enter");
        GameManager.Instance.UIManager.OnDisablePlayActions.Invoke();
    }

    public void OnPointerExit()
    {
        Debug.Log("pointer exit");
        GameManager.Instance.UIManager.OnEnablePlayActions.Invoke();
    }
}
