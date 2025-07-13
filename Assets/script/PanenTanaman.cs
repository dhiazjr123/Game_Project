using System.Collections;
using UnityEngine;

public class PanenTanaman : MonoBehaviour
{
    public int poinPanen = 1;
    public float waktuRespawn = 0f;

    private Vector3 posisiAwal;
    private Collider2D colliderTanaman;
    private SpriteRenderer rendererTanaman;
    private bool sudahDipanen = false;

    void Start()
    {
        posisiAwal = transform.position;
        colliderTanaman = GetComponent<Collider2D>();
        rendererTanaman = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Cegah trigger dobel
        if (sudahDipanen || !rendererTanaman.enabled || !colliderTanaman.enabled) return;

        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            sudahDipanen = true;
            player.AddCoin(poinPanen);
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        // Matikan objek
        rendererTanaman.enabled = false;
        colliderTanaman.enabled = false;

        if (waktuRespawn > 0)
        {
            yield return new WaitForSeconds(waktuRespawn);

            transform.position = posisiAwal;
            rendererTanaman.enabled = true;
            colliderTanaman.enabled = true;
            sudahDipanen = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
