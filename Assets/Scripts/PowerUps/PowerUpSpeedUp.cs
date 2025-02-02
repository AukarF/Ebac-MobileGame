using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeed;


    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.PowerUpSpeedUp(amountToSpeed);
        PlayerController.instance.SetPowerUpText("Speed up");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetSpeed();
        PlayerController.instance.SetPowerUpText("");
    }
}
