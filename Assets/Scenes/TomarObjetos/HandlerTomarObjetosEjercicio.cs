using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerTomarObjetosEjercicio : MonoBehaviour
{
    // El retornar a la escala original requiere usuario perfectos*
    public bool isLifting;
    public bool isObjectNear;
    public GameObject objectTaken;
    private Transform _father;
    public Vector3 originalScale;
    public bool scaleSaveLock;

    private void Awake()
    {
        _father = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isLifting = false;
        isObjectNear = false;
        scaleSaveLock = false;
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
            if (!scaleSaveLock)
            {
                originalScale = other.transform.localScale;
                Debug.Log(originalScale);
                scaleSaveLock = true;
            }
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
                temp.transform.SetParent(_father); //Change parent
                temp.transform.position = transform.position; //Changes xyz with (this) xyz
                temp.transform.rotation = transform.rotation; //Change rotation with (this) rotation
                temp.transform.localScale = transform.localScale; //Change scale to that of the father
                Rigidbody rb = temp.GetComponent<Rigidbody>();
                rb.isKinematic = true; //No external influence
                rb.useGravity = false;  //No gravity
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
                    temp.transform.localScale = originalScale;
                    scaleSaveLock = false;
                }
            }
        }
    }
}
