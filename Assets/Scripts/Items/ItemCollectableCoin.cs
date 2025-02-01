using UnityEngine;

public class ItemCollectableCoin : ItemColletableBase
{
    public Collider2D collider;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.instance.AddCoins();
        collider.enabled = false;
    }
}
