using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : UIComponent
{
    public TextMeshProUGUI seedCount;
    public TextMeshProUGUI levelMatrixText;
    private ClickerManager clickerManager;
    private SeedManager seedManager;
    public Image UpgradeIcon;

    private void Start()
    {
        GameManager.Instance.SeedManager.OnScoreChanged.AddListener(OnSeedCountChanged);
        clickerManager = GameManager.Instance.ClickerManager;
        seedManager = GameManager.Instance.SeedManager;

        OnSeedCountChanged();
        OnLevelChanged();
    }

    private void Update()
    {
        if (seedManager.GetSeeds() >= clickerManager.clickLevel * clickerManager.levelUpgradeCostMultiplier)
            UpgradeIcon.enabled = true;
        else
            UpgradeIcon.enabled = false;
    }

    void OnSeedCountChanged()
    {
        var seeds = GameManager.Instance.SeedManager.GetSeeds();
        seedCount.text = $"Seeds: {seeds}";
    }

    void OnLevelChanged()
    {
        levelMatrixText.text = $"{clickerManager.clickLevel}x{clickerManager.clickLevel}";
    }

    public void OnPlantToolClick()
    {
        Debug.Log("planter tool selected");
        if (seedManager.GetSeeds() >= clickerManager.clickLevel * clickerManager.levelUpgradeCostMultiplier)
        {
            seedManager.AddSeeds(-(clickerManager.clickLevel * clickerManager.levelUpgradeCostMultiplier));
            clickerManager.clickLevel++;
        }
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
