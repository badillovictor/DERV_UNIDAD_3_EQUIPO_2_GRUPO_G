using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_CalcularDistancia : MonoBehaviour
{
    private Transform _objectToMesure;

    private float _distance;
    private void Awake()
    {
        _objectToMesure = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_objectToMesure.position, transform.position);
    }

    public float getDistance()
    {
        return _distance;
    }
}
