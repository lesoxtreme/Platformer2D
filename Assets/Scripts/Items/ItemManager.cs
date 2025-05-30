using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins.Value = 0;
        UpdateUI();
        
    }

    public void AddCoins(int amount = 1)
    {
        coins.Value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.value.ToString();
    }
}
