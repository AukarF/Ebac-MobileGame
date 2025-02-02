using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpBase : ItemColletableBase
{
    [Header("Power Up")] 
    public float duration;

    protected override void OnCollect()
    { 
        base.OnCollect(); 
        StartPowerUp(); 
    }

    protected virtual void StartPowerUp() 
    {
        Debug.Log("Start Power Up"); 
        Invoke(nameof(EndPowerUp), duration); 
    }

    protected virtual void EndPowerUp() 
    {
        Debug.Log("End Power Up"); 
    }
    
}

