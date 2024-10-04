using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClaseSingleton : MonoBehaviour
{
    public static ClaseSingleton Instance { get; private set; }

    /*
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    */

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Instane != null || Instance != this
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneIndex++;
            sceneIndex %= 3;
            SceneChange(sceneIndex);
        }
    }

    public void SceneChange(int index)
    {
        SceneManager.LoadScene(index);
    }
}