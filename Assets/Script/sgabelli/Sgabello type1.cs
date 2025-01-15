using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sgabellotype1 : MonoBehaviour
{
    public GameObject sgabello1;
    public GameObject sgabello2;
    public GameObject sgabello3;
    public GameObject sgabello4;

    //public GameObject cazzetti;

    public int counter = 0;
    // Start is called before the first frame update
    void Awake()
    {
        counter = 0;
        //cazzetti.SetActive(false);
        sgabello2.SetActive(false);
        sgabello3.SetActive(false);
        sgabello4.SetActive(false);
        
        Debug.Log("playerPrefPA" + ScoreHandler.playerPrefPA);
        Debug.Log("playerPrefS" + ScoreHandler.playerPrefS);
        Debug.Log("playerPrefB" + ScoreHandler.playerPrefB);
        Debug.Log("playerPrefFP" + ScoreHandler.playerPrefFP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("martello"))
        {
            Debug.Log("entriamo in collisione");
            if (counter == 0 && ScoreHandler.playerPrefB == 2)
            {
                Debug.Log("counter: "+ counter);
                sgabello1.SetActive(false);
                sgabello2.SetActive(true);
                ScoreHandler.playerPrefB -= 2;
                ScoreHandler.betulla -= 2;
                counter++;
            }

            else if (counter == 1 && ScoreHandler.playerPrefB == 2 && ScoreHandler.playerPrefFP == 1)
            {
                Debug.Log("counter: "+ counter);
                sgabello2.SetActive(false);
                sgabello3.SetActive(true);
                ScoreHandler.playerPrefB -= 2;
                ScoreHandler.betulla -= 2;
                ScoreHandler.playerPrefFP -= 1;
                ScoreHandler.frassino_pioppo -= 1;
                counter++;
            }

            else if (counter == 2 && ScoreHandler.playerPrefB == 2 && ScoreHandler.playerPrefFP == 2 && ScoreHandler.playerPrefS == 1)
            {
                Debug.Log("counter: "+ counter);
                sgabello3.SetActive(false);
                sgabello4.SetActive(true);
                ScoreHandler.playerPrefB -= 2;
                ScoreHandler.betulla -= 2;
                ScoreHandler.playerPrefS -= 1;
                ScoreHandler.salice -= 1;
                ScoreHandler.playerPrefFP -= 2;
                ScoreHandler.frassino_pioppo -= 2;
                //cazzetti.SetActive(true);
                counter++;
            }


            else if (counter >= 2)
            {
                counter = 2;
            }
            
        }
    }
}
