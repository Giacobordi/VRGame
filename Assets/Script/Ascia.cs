using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascia : Strumento_base
// Start is called before the first frame update
{ 
    public Ascia()
    {
        Nome = "Ascia";
        Danno = 1;
        Durabilita = 10;
    }
    public void OnCollisionEnter(Collision other)
    {
        //Debug.Log(alb.Vita);
        if (other.gameObject.CompareTag("Ascia"))
        {
            alb.decrementaVita(ascia.Danno);
            Debug.Log(alb.Vita);
        }
    }
}
