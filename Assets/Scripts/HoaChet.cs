using System.Collections;
using UnityEngine;

public class Hoachet : MonoBehaviour
{
    public float chieuCaoToiThieu = 0f;
    public float thoiGianChuiXuong = 5f;

    private void Start()
    {
        MoveToMinimumPosition();
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

    private void MoveToMinimumPosition()
    {
        StartCoroutine(LerpPosition(new Vector3(transform.position.x, chieuCaoToiThieu, transform.position.z), thoiGianChuiXuong));
    }
}