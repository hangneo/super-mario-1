using System.Collections;
using UnityEngine;

public class HoaAnThit : MonoBehaviour
{
    public float thoiGianNgoiLen = 5f;
    public float thoiGianOTrong = 3f;
    public float thoiGianChuiXuong = 5f;
    public float chieuCaoToiDa = 10f;
    public float chieuCaoToiThieu = 0f;
    public GameObject hoachetPrefabs;


    private IEnumerator Start()
    {
        while (true)
        {
            yield return LerpPosition(new Vector3(transform.position.x, chieuCaoToiDa, transform.position.z), thoiGianNgoiLen);
            yield return new WaitForSeconds(thoiGianOTrong);
            yield return LerpPosition(new Vector3(transform.position.x, chieuCaoToiThieu, transform.position.z), thoiGianChuiXuong);
        }
    }

    private IEnumerator LerpPosition(Vector3 viTriMucTieu, float thoiGian)
    {
        Vector3 viTriBanDau = transform.position;
        float thoiGianDaTieu = 0f;

        while (thoiGianDaTieu < thoiGian)
        {
            float tiLe = thoiGianDaTieu / thoiGian;
            transform.position = Vector3.Lerp(viTriBanDau, viTriMucTieu, tiLe);
            thoiGianDaTieu += Time.deltaTime;
            yield return null;
        }

        transform.position = viTriMucTieu;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dan"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.ResetLevel(3f);
        }
        else if (other.CompareTag("Player"))
        {
            // StartCoroutine(DestroyWithDelay(gameObject, 2f));
            // Destroy(other.gameObject);
            Destroy(gameObject);
            StartCoroutine(HoaChetRoutine());
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
    // private IEnumerator DestroyWithDelay(GameObject obj, float delay)
    // {
    //     SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
    //     Color originalColor = renderer.color;
    //     renderer.color = Color.gray;
    //     obj.transform.Rotate(new Vector3(0f, 0f, 180f));

    //     yield return new WaitForSeconds(delay);

    //     yield return LerpPosition(new Vector3(obj.transform.position.x, chieuCaoToiThieu, obj.transform.position.z), thoiGianChuiXuong);
    //     Destroy(obj);

    //     renderer.color = originalColor;
    // }
    private IEnumerator HoaChetRoutine()
    {
        GameObject hoachet = Instantiate(hoachetPrefabs, transform.position, Quaternion.identity);
        yield return StartCoroutine(LerpPosition(new Vector3(transform.position.x, chieuCaoToiThieu, transform.position.z), thoiGianChuiXuong));
        Destroy(hoachet);
    }
}