using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayRoi : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject may;
    private Rigidbody2D mayrid;
    void Start()
    {
        mayrid = may.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mayrid.gravityScale = 15;
        }
    }
}
