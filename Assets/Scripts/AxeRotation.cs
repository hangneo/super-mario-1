using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeRotation : MonoBehaviour
{
    // Start is called before the first frame update
  public float _gocmax = 60f;
    public float _speed = 3f; 
    private float _rotatatehientai; 
    void Start()
    {
        _rotatatehientai = transform.eulerAngles.z;

    }

    // Update is called once per frame
    void Update()
    {
         float _dungsin = Mathf.Sin(Time.time * _speed) * _gocmax;
        transform.rotation = Quaternion.Euler(0, 0, _rotatatehientai + _dungsin);

        
    }
    }
