using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] List<PowerUpSO> powerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (PowerUpSO powerup in powerUpEffect)
            {
                powerup.Apply(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
