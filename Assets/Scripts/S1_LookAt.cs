using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_LookAt : MonoBehaviour
{
    private Transform _objectToLookAt;
    
    private S2_CalcularDistancia _calcularDistancia;
    
    private void Awake()
    {
        _objectToLookAt = GameObject.Find("Jugador").GetComponent<Transform>();
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
        if (distanceToEnemy < 10.0f)
        {
            float valY = _objectToLookAt.position.y;
            if (valY > 2.5f)
            {
                transform.LookAt(new Vector3(_objectToLookAt.position.x, valY, _objectToLookAt.position.z));
            }
            else
            {
                transform.LookAt(_objectToLookAt);
            }
        }
    }
}
