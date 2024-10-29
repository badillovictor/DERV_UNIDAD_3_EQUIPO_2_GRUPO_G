using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ManagerUIadv : MonoBehaviour
{
    private static ManagerUIadv InstanceManagerUIadv { get; set; }

    [SerializeField] private GameObject userNameInputField;
    private TextMeshProUGUI _txtUserName;
    private String _username;
    private int _sceneID;

    private void Awake()
    {
        if (InstanceManagerUIadv == null)
        {
            InstanceManagerUIadv = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
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
        _sceneID = SceneManager.GetActiveScene().buildIndex;
        if (_sceneID != 0)
        {
            _username = PlayerPrefs.GetString("username");
            Debug.Log(_username);
        }
    }

    public void ChangeScene(int sceneID)
    {
        if (_sceneID == 0)
        {
            _txtUserName = userNameInputField.GetComponent<TextMeshProUGUI>();
            _username = _txtUserName.text;
            PlayerPrefs.SetString("username", _username);
        }
        SceneManager.LoadScene(sceneID);
    }
}
