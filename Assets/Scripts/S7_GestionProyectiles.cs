using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S7_GestionProyectiles : MonoBehaviour
{
    [SerializeField] private GameObject projectile; //Prefab que se va a copiar y pegar
    [SerializeField] private Transform spawnProjectiles; //Spawn de los proyectiles
    [SerializeField] private List<GameObject> projectiles;
    private int _numberProjectiles;
    private int _projectileToDump;
    
    // Start is called before the first frame update
    void Start()
    {
        _numberProjectiles = 10;
        projectiles = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < _numberProjectiles; i++)
        {
            Debug.Log("Creacion proyectil");
            temp = Instantiate<GameObject>(projectile, spawnProjectiles.position, spawnProjectiles.rotation);
            temp.name = "Projectile" + i;
            temp.tag = "Bullet";
            temp.SetActive(false);
            projectiles.Add(temp);
        }
        _projectileToDump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            projectiles[_projectileToDump].transform.position = spawnProjectiles.position;
            projectiles[_projectileToDump].transform.rotation = spawnProjectiles.rotation;
            projectiles[_projectileToDump].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            projectiles[_projectileToDump].SetActive(true);
            _projectileToDump++;
            _projectileToDump %= projectiles.Count;
        }
    }
}
