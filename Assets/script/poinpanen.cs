using UnityEngine;

public class poinpanen : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.AddCoin(coinValue); // Tambahkan poin ke player
            Destroy(gameObject);       // Hapus tanaman setelah dipanen
        }
    }
}
