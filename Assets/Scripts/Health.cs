using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health, maxHealth = 50;
    [SerializeField] ParticleSystem laserHitEffect;
    [SerializeField] string hitSound;
    [SerializeField] string destroyedSound;

    [SerializeField] bool isPlayer;
    [SerializeField] int scoreEnemyDestroyed = 100;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    PowerUpSpawner powerUpSpawner;

    public int CurrentHealth { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        powerUpSpawner = FindObjectOfType<PowerUpSpawner>();
    }

    public int GetHealth()
    {
        return health;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            PlayHitSound();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    void PlayHitSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(hitSound);
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        FMODUnity.RuntimeManager.PlayOneShot(destroyedSound);
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(scoreEnemyDestroyed);
            if (powerUpSpawner)
            {
                powerUpSpawner.spawnPowerup();
            }
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (laserHitEffect != null)
        {
            ParticleSystem instance = Instantiate(laserHitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
