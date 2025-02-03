using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollectableCoin : ItemColletableBase
{
    public Collider collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    private void Start()
    {
        //CoinsAnimationManager.Instance.RegisterCoin(this);
    }


    protected override void OnCollect()
    {
        //OnCollect();
        //ItemsManager.instance.AddCoins();
        collider.enabled = false;
        collect = true;
        //PlayerController.instance.Bounce();
    }
    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position,
           PlayerController.instance.transform.position, lerp * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <
           minDistance)
            {
                //HideItens();
                Destroy(gameObject);
            }
        }
    }
}
