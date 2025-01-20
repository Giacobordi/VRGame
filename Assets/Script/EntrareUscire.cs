using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrareUscire : MonoBehaviour
{
    public GameObject Player;
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
        Debug.Log("OnTriggerEnter");
        
        
        if (other.CompareTag("Entra"))
        {
            Player.transform.position = new Vector3(64.25975f, 11.42f, 0.04306793f);
            
            PlayerPrefs.SetInt("pino_abete", ScoreHandler.pino_abete);
            PlayerPrefs.SetInt("salice", ScoreHandler.salice);
            PlayerPrefs.SetInt("betulla", ScoreHandler.betulla);
            PlayerPrefs.SetInt("frassino_pioppo", ScoreHandler.frassino_pioppo);
            
            ScoreHandler.playerPrefPA = PlayerPrefs.GetInt("pino_abete");
            ScoreHandler.playerPrefS = PlayerPrefs.GetInt("salice");
            ScoreHandler.playerPrefB = PlayerPrefs.GetInt("betulla");
            ScoreHandler.playerPrefFP = PlayerPrefs.GetInt("frassino_pioppo");
            
            Debug.Log("scico entra");
        }
        
        if (other.CompareTag("Esci"))
        {
            Player.transform.position = new Vector3(-123.99f, 2.42f, 104.1f);
            Debug.Log("scico esce");
        }
    }
}
