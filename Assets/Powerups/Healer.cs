using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="PowerUps/HealthUp")]
public class Healer : PowerUpSO
{
    [SerializeField] int amount;
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<Health>().CurrentHealth < target.GetComponent<Health>().MaxHealth)
        {
            target.GetComponent<Health>().CurrentHealth += amount;
        }
    }
}
