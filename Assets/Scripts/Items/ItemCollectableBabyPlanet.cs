using UnityEngine;

public class ItemCollectableBabyPlanet : ItemColletableBase
{
    public Collider2D collider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.instance.AddBabyPlanets();
        collider.enabled = false;
    }
}
