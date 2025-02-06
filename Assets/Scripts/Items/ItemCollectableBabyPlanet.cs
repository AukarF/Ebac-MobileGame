using UnityEngine;

public class ItemCollectableBabyPlanet : ItemColletableBase
{
    public Collider2D collider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.Instance.AddBabyPlanets();
        collider.enabled = false;
    }
}
