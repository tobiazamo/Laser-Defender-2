using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [Header("Laser")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float firingRate = 0.2f;

    [Header("Object")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileLifetime = 5f;

    [Header("AI")]
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] float minFireRate = 0.1f;
    [SerializeField] bool useAI;

    [Header("Audio")]
    [SerializeField] string oneShotForRaySound;

    public bool isFiring;

    Coroutine firingCoroutine;

    public float FiringRate { get => firingRate; set => firingRate = value; }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }


    void Update()
    {
        Fire();
        
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject instance = Instantiate(
                projectilePrefab, 
                transform.position, 
                Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            float timetonextprojectile = Random.Range(firingRate - fireRateVariance, firingRate + fireRateVariance);
            timetonextprojectile = Mathf.Clamp(timetonextprojectile, minFireRate, float.MaxValue);

            FMODUnity.RuntimeManager.PlayOneShot(oneShotForRaySound);

            yield return new WaitForSeconds(timetonextprojectile);
        }

    }
}
