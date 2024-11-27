using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class alberoInteragibile : MonoBehaviour
{
    public Albero_base alb;
    public Ascia ascia;
    public GameObject albero;
    public GameObject albero_cadente;
    public tipo albero_da_spawnare;
    public enum tipo
    {
        acero,
        pino
    }

    // Start is called before the first frame update
    void Start()
    {
        ascia = GameSingleton.instance.ascia;
        albero_cadente.SetActive(false);

        switch (albero_da_spawnare)
        {
            case tipo.acero: alb = new Acero();
                break;
            case tipo.pino: alb = new Pino();
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(alb.Vita == 0)
        {
            albero_cadente.SetActive(true);
            Destroy(gameObject);
            UI.contatore_pezzi += alb.Pezzi;
        }
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
