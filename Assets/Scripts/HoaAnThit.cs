using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoaAnThit : MonoBehaviour
{
   public GameObject objectToShow;
    public float hideDelay = 5f;
    public float showDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(HideAndShow());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator HideAndShow()
    {
        while (true)
        {
            // Ẩn GameObject trong 5 giây
            objectToShow.SetActive(false);
            yield return new WaitForSeconds(hideDelay);

            // Hiện GameObject trong 3 giây
            objectToShow.SetActive(true);
            yield return new WaitForSeconds(showDelay);
        }
    }
}
