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
        if (seedManager.GetSeeds() >= GetCost())
            UpgradeIcon.enabled = true;
        else
            UpgradeIcon.enabled = false;

        OnLevelChanged();
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

    int GetCost()
    {
        return (clickerManager.clickLevel + 1) * clickerManager.clickLevel;
    }

    public void OnPlantToolClick()
    {
        Debug.Log("planter tool selected");
        if (seedManager.GetSeeds() >= GetCost())
        {
            seedManager.AddSeeds(-GetCost());
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
