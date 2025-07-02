using UnityEngine;

public class TanamLangsung : MonoBehaviour
{
    public GameObject prefabPadiMuda;
    public float jarakTanam = 1f;
    public KeyCode tombolTanam = KeyCode.E;
    public Grid gridLayout; // 🔧 drag dari scene

    void Update()
    {
        if (Input.GetKeyDown(tombolTanam))
        {
            CobaTanam();
        }
    }

    void CobaTanam()
    {
        Vector3 posisiTanam = transform.position + Vector3.down * jarakTanam;

        Collider2D tanah = Physics2D.OverlapCircle(posisiTanam, 0.2f);
        if (tanah != null && tanah.CompareTag("Tanah"))
        {
            Vector3Int cellPos = gridLayout.LocalToCell(posisiTanam);
            Vector3 snapPos = gridLayout.CellToWorld(cellPos) + new Vector3(0.5f, 0.5f, 0);
            Instantiate(prefabPadiMuda, snapPos, Quaternion.identity);
        }
    }
}
