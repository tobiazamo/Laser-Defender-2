using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject splashDamage;
    [SerializeField] float splashRadius = 2f;

    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        splashDamage.GetComponent<CircleCollider2D>().radius = splashRadius;
    }

    private void FixedUpdate()
    {

        if (hasTarget)
        {

            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;

            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            //Debug.Log(angle);
            rb.rotation = angle;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        }
        else
        {

            rb.velocity = Vector2.up * moveSpeed;
        }

    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            ParticleSystem particle = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(particle.gameObject, particle.main.duration + particle.main.startLifetime.constantMax);

            GameObject areaDamage = Instantiate(splashDamage, transform.position, Quaternion.identity);
            Destroy(areaDamage.gameObject, particle.main.duration + particle.main.startLifetime.constantMax);

            Destroy(GetComponentInParent<Rigidbody2D>().gameObject);
        }
    }
}
