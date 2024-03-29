using System.Collections;
using UnityEngine;

public class HoaAnThit : MonoBehaviour
{
    public float thoiGianNgoiLen = 5f;
    public float thoiGianOTrong = 3f;
    public float thoiGianChuiXuong = 5f;
    public float chieuCaoToiDa = 10f;
    public float chieuCaoToiThieu = 0f;
    
    
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
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.ResetLevel(3f);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
    
}