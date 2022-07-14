using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="PowerUps/Tracking Rocket Ammo")]
public class TrackingRocketAmmo : PowerUpSO
{
    [SerializeField] int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().RocketAmount += amount;
    }
}
