using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S4_PosicionEnemigos : MonoBehaviour
{
    [SerializeField] private Transform _spawnLocation;
    GameObject _enemigo;

    private void Awake()
    {
        _enemigo = GameObject.Find("Enemigo");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Activo Trigger");
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisiono Player");
            _enemigo.transform.position = _spawnLocation.position;
        }
    }
}
