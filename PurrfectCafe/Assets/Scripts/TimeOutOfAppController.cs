using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutOfAppController : MonoBehaviour
{
    // Start is called before the first frame update
    public static TimeOutOfAppController Instance { get; private set; }
    public float timePasedOut = 0;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        Debug.Log("app Open");
        string dateQuitString = PlayerPrefs.GetString("dateQuit", "");
        if (!dateQuitString.Equals(""))
        {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;

            if (dateNow > dateQuit)
            {
                TimeSpan timeSpan = dateNow - dateQuit;
                Debug.Log("quit for: " + timeSpan.TotalSeconds);
                timePasedOut = (float)timeSpan.TotalSeconds;
                Debug.Log("quit for: " + timePasedOut);
                
            }
            PlayerPrefs.SetString("dateQuit", "");
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log("app Quit");
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString());
        Debug.Log(""+dateQuit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
