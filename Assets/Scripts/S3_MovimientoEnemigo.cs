using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_MovimientoEnemigo : MonoBehaviour
{
    private Transform _playerLocation;
    private S2_CalcularDistancia _calcularDistancia;

    private void Awake()
    {
        _playerLocation = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _calcularDistancia = GetComponent<S2_CalcularDistancia>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToEnemy = _calcularDistancia.getDistance();
        float velocidad = 5f * Time.deltaTime;
        if (distanceToEnemy < 10.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerLocation.position, velocidad);
        }
    }
}
