using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_FuerzasIntro : MonoBehaviour
{
    private Rigidbody _rb;
    private float _forceVelocity;
    private float _screenTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _screenTime = 0f;
        _rb = GetComponent<Rigidbody>();
        _forceVelocity = 150f;
        /*
        //Instantaneos
        _rb.AddForce(_forceVelocity * transform.right, ForceMode.Impulse);      //Considera Masa
        _rb.AddForce(5f * -1 * transform.forward, ForceMode.VelocityChange);    //Ignoras Masa
        //Continuas
        // ForceMode.Acceleration   //Ignora Masa
        // ForceMode.Force          //Considera Masa
        */
    }

    // Update is called once per frame
    void Update()
    {
        _screenTime += Time.deltaTime;
        if (_screenTime > 1.5f)
        {
            _screenTime = 0;
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Time.fixedDeltaTime * _forceVelocity * transform.forward, ForceMode.Impulse);
        /*
        _rb.AddForce(10f * -1 * transform.right, ForceMode.Acceleration);
        _rb.AddForce(10f * transform.forward, ForceMode.Force);
        */
    }
}
