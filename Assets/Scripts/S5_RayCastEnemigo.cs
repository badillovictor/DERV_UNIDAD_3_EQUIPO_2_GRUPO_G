using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S5_RayCastEnemigo : MonoBehaviour
{
    private Transform _jugador;

    private void Awake()
    {
        _jugador = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = _jugador.position - transform.position;
        direccion = direccion.normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direccion, out hit, 10f))
        {
            Debug.Log("Colision objeto");
            Debug.DrawRay(transform.position, direccion * hit.distance, Color.blue);
        }
        else
        {
            Debug.Log("No Colision objeto");
            Debug.DrawRay(transform.position, direccion * 10f, Color.red);
        }
    }
}
