using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int rocketAmount = 3;
    [SerializeField] GameObject rocketPrefab;
    Vector2 moveInput;

    [SerializeField] float paddingTop;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;

    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    public int RocketAmount { get => rocketAmount; set => rocketAmount = value; }

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }


    void Start()
    {
        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 delta = moveInput * moveSpeed * Time.deltaTime;
        Vector2 playerMoveSpeed = new Vector2();
        playerMoveSpeed.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        playerMoveSpeed.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = playerMoveSpeed;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void OnAltFire(InputValue value)
    {
        if (rocketAmount > 0)
        {
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            rocketAmount--;
        }
    }
}