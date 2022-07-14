using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PowerUps/Side Guns")]
public class SideGuns : PowerUpSO
{
    [SerializeField] List<GameObject> sideGuns;
    [SerializeField] float fireRateIncrease = 0.2f;

    public override void Apply(GameObject target)
    {
      foreach (GameObject gun in sideGuns)
       {
            if (gun.scene.IsValid())
            {
                gun.GetComponent<Shooter>().FiringRate += fireRateIncrease;
            }
            else
            {
                Instantiate(gun, target.transform);
            }
       } 
    }
}
