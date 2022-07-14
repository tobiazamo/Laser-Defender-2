using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] List<GameObject> powerUps;

    [Header("Parameters")]
    [SerializeField] [Range(0, 100)] float spawnChance;
    [SerializeField] float fallSpeed = 3f;
    [SerializeField] float powerUpLifetime = 20f;

    public void spawnPowerup()
    {
        if(Random.value <= (spawnChance / 100))
        {
            GameObject instance = Instantiate(powerUps[Random.Range(0, powerUps.Count)], transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * fallSpeed;
            }
            Destroy(instance, powerUpLifetime);
        }
    }
    
}
