using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HandlerTomarObjetos : MonoBehaviour
{
    public bool isLifting;
    public bool isObjectNear;
    public GameObject objectTaken;
    private GameObject _father;
    public Vector3 originalScale;

    private void Awake()
    {
        _father = GameObject.Find("PlayerCharacter");
    }

    // Start is called before the first frame update
    void Start()
    {
        isLifting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isLifting = !isLifting;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Liftable"))
        {
            isObjectNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Liftable"))
        {
            isObjectNear = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Liftable"))
        {
            GameObject temp = other.gameObject; //Gets object instance
            //int scaleFactor = 1;
            if (isObjectNear && isLifting)
            {
                objectTaken = temp;
                temp.transform.SetParent(_father.transform); //Change parent
                Rigidbody rb = temp.GetComponent<Rigidbody>();
                rb.isKinematic = true; //No external influence
                rb.useGravity = false;  //No gravity
                originalScale = temp.transform.localScale;
                temp.transform.position = transform.position; //Changes xyz with (this) xyz
                temp.transform.rotation = transform.rotation; //Change rotation with (this) rotation
                temp.transform.localScale = transform.localScale; //Change scale to that of the father
            }
            else
            {
                if (objectTaken != null)
                {
                    objectTaken = null;
                    temp.transform.SetParent(null);
                    Rigidbody rb = temp.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    temp.transform.localScale = transform.localScale;
                    temp.transform.localScale = originalScale; 
                }
            }
        }
    }
}
