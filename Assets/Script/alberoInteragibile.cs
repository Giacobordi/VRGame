using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class alberoInteragibile : MonoBehaviour
{
    public Albero_base alb;
    public Ascia ascia;
    //public GameObject albero;
    //public GameObject albero_cadente;
    public tipo albero_da_spawnare;
    public GameObject ciocco;
    public GameObject spawner;
    public Vector3 spawner_pos;
    public float distance = 1.5f;
    public enum tipo
    {
        acero,
        pino
    }

    // Start is called before the first frame update
    void Start()
    {
        ascia = GameSingleton.instance.ascia;
        //albero_cadente.SetActive(false);

        switch (albero_da_spawnare)
        {
            case tipo.acero: alb = new Acero();
                break;
            case tipo.pino: alb = new Pino();
                break;
        }
        Vector3 spawner_pos2 = new Vector3(Random.Range(spawner.transform.position.x + distance, spawner.transform.position.x - distance), spawner.transform.position.y , Random.Range(spawner.transform.position.z + distance, spawner.transform.position.z - distance) );
        spawner_pos = spawner_pos2;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(alb.Vita == 0)
        {
            //albero_cadente.SetActive(true);
            //Destroy(gameObject);
            gameObject.SetActive(false);
            for (int i = 0; i < 3; i++)
            { 
                Instantiate(ciocco, spawner_pos, Quaternion.identity);     
            }

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
