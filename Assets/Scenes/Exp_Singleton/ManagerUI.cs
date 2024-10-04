using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance { get; private set; }
    
    TextMeshProUGUI []_textTimer;
    private float _secondsTimer;
    float _enlapsedTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _textTimer = GetComponentsInChildren<TextMeshProUGUI>();
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
        _secondsTimer = 0;
        _enlapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _enlapsedTime += Time.deltaTime;
        if (_enlapsedTime >= 1f)
        {
            _secondsTimer++;
            _enlapsedTime = 0;
            _textTimer[1].text = _secondsTimer.ToString();
        }
    }
}
