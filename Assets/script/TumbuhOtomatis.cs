using UnityEngine;

public class TumbuhOtomatis : MonoBehaviour
{
    public GameObject prefabPadiMatang;
    public float waktuTumbuh = 8f;

    void Start()
    {
        Invoke("Tumbuh", waktuTumbuh);
    }

    void Tumbuh()
    {
        Instantiate(prefabPadiMatang, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
