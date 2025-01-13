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
            if (counter == 0)
            {
                Debug.Log("counter: "+ counter);
                tavolo1.SetActive(false);
                tavolo2.SetActive(true);
                counter++;
            }

            else if (counter == 1)
            {
                Debug.Log("counter: "+ counter);
                tavolo2.SetActive(false);
                tavolo3.SetActive(true);
                counter++;
            }

            else if (counter == 2)
            {
                Debug.Log("counter: "+ counter);
                tavolo3.SetActive(false);
                tavolo4.SetActive(true);
                cazzetti.SetActive(true);
                counter++;
            }


            else if (counter >= 2)
            {
                counter = 2;
            }
        }
    }
}
