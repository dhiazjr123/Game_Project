using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Jangan lupa pakai ini kalau pakai TextMeshProUGUI

public class PlayerMovement : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }

    [SerializeField] private float moveSpeed = 1f;
    private PlayerController playerControl;  // Script auto-generated dari Input Action
    private Vector2 movement;
    private Rigidbody2D rb;

    private Animator anim;
    public SpriteRenderer sprite;
    private bool facingLeft = false;

    [Header("Coin System")]
    public int currentCoin = 0;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        playerControl = new PlayerController();  // pastikan nama sesuai file yang digenerate
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        // Ambil input movement dari Input System baru
        movement = playerControl.Movement.Movement.ReadValue<Vector2>();

        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        if (movement.x != 0f)
        {
            sprite.flipX = movement.x < 0f;
            FacingLeft = true;
        }
        else if (movement.y != 0f)
        {
            sprite.flipX = false;
            FacingLeft = false;
        }
    }

    // Fungsi untuk menambah koin
    public void AddCoin(int amount)
    {
        currentCoin += amount;
        if (coinText != null)
            coinText.text = "Poin : " + currentCoin.ToString();
    }
}
