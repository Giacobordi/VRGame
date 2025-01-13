using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creaTavolo : MonoBehaviour
{
    public GameObject tavolo1;
    public GameObject tavolo2;
    public GameObject tavolo3;
    public GameObject tavolo4;

    public GameObject cazzetti;

    public int counter = 0;
    // Start is called before the first frame update
    void Awake()
    {
        counter = 0;
        cazzetti.SetActive(false);
        tavolo1.SetActive(true);
        tavolo2.SetActive(false);
        tavolo3.SetActive(false);
        tavolo4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("martello"))
        {
            if (counter == 0 && ScoreHandler.playerPrefPA == 3 && ScoreHandler.playerPrefS == 3 && ScoreHandler.playerPrefB == 3 && ScoreHandler.playerPrefFP == 3)
            {
                Debug.Log("counter: "+ counter);
                tavolo1.SetActive(false);
                tavolo2.SetActive(true);
                ScoreHandler.playerPrefB -= 3;
                ScoreHandler.betulla -= 3;
                ScoreHandler.playerPrefFP -= 3;
                ScoreHandler.frassino_pioppo -= 3;
                ScoreHandler.playerPrefPA -= 3;
                ScoreHandler.pino_abete -= 3;
                ScoreHandler.playerPrefS -= 3;
                ScoreHandler.salice -= 3;
                counter++;
            }

            else if (counter == 1 && ScoreHandler.playerPrefPA == 5 && ScoreHandler.playerPrefS == 5 && ScoreHandler.playerPrefB == 5 && ScoreHandler.playerPrefFP == 5)
            {
                Debug.Log("counter: "+ counter);
                tavolo2.SetActive(false);
                tavolo3.SetActive(true);
                ScoreHandler.playerPrefB -= 5;
                ScoreHandler.betulla -= 5;
                ScoreHandler.playerPrefFP -= 5;
                ScoreHandler.frassino_pioppo -= 5;
                ScoreHandler.playerPrefPA -= 5;
                ScoreHandler.pino_abete -= 5;
                ScoreHandler.playerPrefS -= 5;
                ScoreHandler.salice -= 5;
                counter++;
            }

            else if (counter == 2 && ScoreHandler.playerPrefPA == 7 && ScoreHandler.playerPrefS == 7 && ScoreHandler.playerPrefB == 7 && ScoreHandler.playerPrefFP == 7)
            {
                Debug.Log("counter: "+ counter);
                tavolo3.SetActive(false);
                tavolo4.SetActive(true);
                cazzetti.SetActive(true);
                ScoreHandler.playerPrefB -= 7;
                ScoreHandler.betulla -= 7;
                ScoreHandler.playerPrefFP -= 7;
                ScoreHandler.frassino_pioppo -= 7;
                ScoreHandler.playerPrefPA -= 7;
                ScoreHandler.pino_abete -= 7;
                ScoreHandler.playerPrefS -= 7;
                ScoreHandler.salice -= 7;
                counter++;
            }


            else if (counter >= 2)
            {
                counter = 2;
            }

        }
    }
}
