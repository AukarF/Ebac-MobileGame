using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpInvincible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Invencible");
        PlayerController.Instance.SetInvencible();
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetInvencible(false);
        PlayerController.Instance.SetPowerUpText("");
    }
}
