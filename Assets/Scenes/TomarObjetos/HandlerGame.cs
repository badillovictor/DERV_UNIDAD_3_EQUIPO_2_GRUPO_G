using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class HandlerGame : MonoBehaviour
{
    public List<GameObject> cubeList;   //Lista de cubos en el mapa
    public int currentObjective;    //Cubo el cual es el objetivo actual
    public bool isPlaying;  //Variable que checa si el jugador tiene un objetivo actual
    public TextMeshProUGUI objectiveText;   //TMP que muestra el objetivo actual
    public bool gameComplete;   //Bandera de jeugo completado

    private void Awake()
    {
        cubeList.Add(GameObject.Find("RedCube"));
        cubeList.Add(GameObject.Find("YellowCube"));
        cubeList.Add(GameObject.Find("PurpleCube"));
        objectiveText = GameObject.Find("TextCubo").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameComplete = false;
        ChangeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        while (!isPlaying && !gameComplete)
        {
            if (cubeList.Count > 0)
            {
                cubeList.Remove(cubeList[currentObjective]);
            }
            else
            {
                gameComplete = true;
                objectiveText.text = "Game Complete!";
            }
            ChangeTarget();
        }
    }

    void ChangeTarget()
    {
        if (cubeList.Count > 0)
        {
            isPlaying = true;
            currentObjective = Random.Range(0, cubeList.Count);
            GameObject temp = cubeList[currentObjective];
            temp.tag = "Liftable";
            objectiveText.text = temp.name;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Liftable"))
        {
            other.tag = "Cube";
            isPlaying = false;
        }
    }
}
