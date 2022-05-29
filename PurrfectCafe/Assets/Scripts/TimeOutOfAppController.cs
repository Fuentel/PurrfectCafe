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
        if (PlayerPrefs.HasKey("dateQuit"))
        {
            DateTime dateQuit = DateTime.Parse(PlayerPrefs.GetString("dateQuit"));
            DateTime dateNow = DateTime.Now;

            if (dateNow > dateQuit)
            {
                TimeSpan timeSpan = dateNow - dateQuit;
                Debug.Log("quit for: " + timeSpan.TotalSeconds);
                timePasedOut = (float)timeSpan.TotalSeconds;
                Debug.Log("quit for: " + timePasedOut);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
