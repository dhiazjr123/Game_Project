using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TanamManager : MonoBehaviour
{
    public Button tombolTanam;
    public GameObject player;
    public float jarakTanam = 1.5f;

    private GameObject targetPadiMuda;
    private Vector3 posisiTanam;
    private GameObject prefabYangAkanDitumbuhkan;

    void Start()
    {
        tombolTanam.onClick.AddListener(Tanam);
    }

    void Update()
    {
        CariTanamanMudaTerdekat();
    }

    void CariTanamanMudaTerdekat()
    {
        GameObject[] bibit = GameObject.FindGameObjectsWithTag("PadiMuda"); // Gunakan tag yang sama untuk semua biji
        float jarakTerdekat = Mathf.Infinity;

        foreach (GameObject tanaman in bibit)
        {
            float jarak = Vector3.Distance(player.transform.position, tanaman.transform.position);
            if (jarak < jarakTanam && jarak < jarakTerdekat)
            {
                targetPadiMuda = tanaman;
                posisiTanam = tanaman.transform.position;
                jarakTerdekat = jarak;
            }
        }
    }

    void Tanam()
    {
        if (targetPadiMuda != null)
        {
            TanamanData data = targetPadiMuda.GetComponent<TanamanData>();
            if (data != null && data.prefabMatang != null)
            {
                prefabYangAkanDitumbuhkan = data.prefabMatang;
                Destroy(targetPadiMuda);
                StartCoroutine(MunculkanTanamanMatang());
            }
            else
            {
                Debug.LogWarning("Prefab matang belum diisi di TanamanData!");
            }
        }
    }

    IEnumerator MunculkanTanamanMatang()
    {
        yield return new WaitForSeconds(3f); // Waktu tumbuh
        Instantiate(prefabYangAkanDitumbuhkan, posisiTanam, Quaternion.identity);
    }
}
