using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreHandler : MonoBehaviour
{
    public static int pino_abete;
    public static int salice;
    public static int betulla;
    public static int frassino_pioppo;

    public static int playerPrefPA;
    public static int playerPrefS;
    public static int playerPrefB;
    public static int playerPrefFP;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pino_abete"))
        {
            pino_abete++;
            Destroy(other.gameObject);
            Debug.Log(pino_abete);
        }
        else if (other.CompareTag("salice"))
        {
            salice++;
            Destroy(other.gameObject);
            Debug.Log(salice);
        }
        else if (other.CompareTag("betulla"))
        {
            betulla++;
            Destroy(other.gameObject);
            Debug.Log(betulla);
        }
        else if (other.CompareTag("frassino_pioppo"))
        {
            frassino_pioppo++;
            Destroy(other.gameObject);
            Debug.Log(frassino_pioppo);
        }
    }

    public void OnEnable()
    {
        playerPrefPA = PlayerPrefs.GetInt("pino_abete");
        playerPrefS = PlayerPrefs.GetInt("salice");
        playerPrefB = PlayerPrefs.GetInt("betulla");
        playerPrefFP = PlayerPrefs.GetInt("frassino_pioppo");

        Debug.Log("pino_abete = " + pino_abete);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("pino_abete", pino_abete);
        PlayerPrefs.SetInt("salice", salice);
        PlayerPrefs.SetInt("betulla", betulla);
        PlayerPrefs.SetInt("frassino_pioppo", frassino_pioppo);
    }
}
