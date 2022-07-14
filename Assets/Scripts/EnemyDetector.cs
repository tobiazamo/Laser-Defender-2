using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    RocketMovement rocketMovement;

    private void Awake()
    {
        rocketMovement = FindObjectOfType<RocketMovement>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            rocketMovement.SetTarget(collision.transform.position);
        }
    }
}
