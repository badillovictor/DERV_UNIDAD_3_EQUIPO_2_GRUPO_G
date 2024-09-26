using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_MovRotCompuesto : MonoBehaviour
{
    float _moveSpeed;
    float _rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _moveSpeed = 10f;
        _rotateSpeed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        float angulo = 5f * _rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) //Adelante
        {
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S)) //Atras
        {
            transform.position += transform.forward * _moveSpeed * Time.deltaTime * -1;
        }

        if(Input.GetKey(KeyCode.A)) //Izquierda
        {
            transform.position += transform.right * _moveSpeed * Time.deltaTime * -1;
        }
        else if (Input.GetKey(KeyCode.D)) //Derecha
        {
            transform.position += transform.right * _moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q)) //Izquierda
        {
            transform.Rotate(0, angulo * -1, 0);
        }
        else if (Input.GetKey(KeyCode.E)) //Derecha
        {
            transform.Rotate(0, angulo, 0);
        }
    }
}
