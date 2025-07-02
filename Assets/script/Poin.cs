using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poin : MonoBehaviour
{
    public int coinValue = 1;
    public float respawnTime = 5f; // Waktu delay respawn

    private Vector3 startPosition;
    private Collider2D objectCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        startPosition = transform.position;
        objectCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.AddCoin(coinValue);
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        // Sembunyikan objek
        spriteRenderer.enabled = false;
        objectCollider.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        // Tampilkan kembali objek
        transform.position = startPosition;
        spriteRenderer.enabled = true;
        objectCollider.enabled = true;
    }
}
