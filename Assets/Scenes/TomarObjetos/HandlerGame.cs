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
    public List<GameObject> cubeList;
    //private List<int> _cubeIndexControlList;
    public int currentObjective;
    public bool isPlaying;
    public TextMeshProUGUI objectiveText;
    public bool gameComplete;

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
        //_cubeIndexControlList = new List<int>{0, 1, 2};
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
