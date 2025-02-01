using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using TMPro;

public class ItemsManager : Singleton<ItemsManager>
{
    public SOInt2 babyPlanets;
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextBabyPlanets;

    private void Start()
    {
        Reset();
    }


    private void Reset()
    {
        coins.value = 0;
        babyPlanets.value = 0;
        UptadeUI();
    }


    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UptadeUI();
    }

    public void AddBabyPlanets(int amount = 1)
    {
        babyPlanets.value += amount;
        UptadeUI();
    }


    private void UptadeUI()
    {
        /*uiTextCoins.text = coins.ToString();
        uiTextBabyPlanets.text = babyPlanets.ToString();
        UiInGameManager.UptadeTextCoins(coins.value.ToString());
        UiInGameManager.UptadeTextBabyPlanets(babyPlanets.value.ToString());*/
    }

}
