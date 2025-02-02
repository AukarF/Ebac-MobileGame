using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpCoins : PowerUpBase
{
    [Header("Coin Collector")]
    public float sizeAmount = 7;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.ChangeCoinCollectorSize(sizeAmount);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ChangeCoinCollectorSize(1);
    }
}