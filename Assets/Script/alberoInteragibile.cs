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
    public int AlberoVita;

    public static bool alberoATerra;
    public enum tipo
    {
        pino,
        abete,
        betulla,
        frassino,
        pioppo,
        salice
    }

    // Start is called before the first frame update
    void Start()
    {
        ascia = GameSingleton.instance.ascia;
        //albero_cadente.SetActive(false);

        switch (albero_da_spawnare)
        {
            case tipo.pino: alb = new Pino();
                break;
            case tipo.abete: alb = new Abete();
                break;
            case tipo.betulla: alb = new Betulla();
                break;
            case tipo.frassino: alb = new Frassino();
                break;
            case tipo.pioppo: alb = new Pioppo();
                break;
            case tipo.salice: alb = new Salice();
                break;
        }
        
        Vector3 spawner_pos2 = new Vector3(Random.Range(spawner.transform.position.x + distance, spawner.transform.position.x - distance), spawner.transform.position.y , Random.Range(spawner.transform.position.z + distance, spawner.transform.position.z - distance) );
        spawner_pos = spawner_pos2;

        AlberoVita = alb.Vita;

;
    }
    // Update is called once per frame
    void Update()
    {
        if(alb.Vita == 0)
        {
            alberoATerra = true;
            //albero_cadente.SetActive(true);
            //Destroy(gameObject);
            gameObject.SetActive(false);
            
            for (int i = 0; i < AlberoVita; i++)
            { 
                Instantiate(ciocco, spawner_pos, Quaternion.identity);     
            }

            UI.contatore_pezzi += alb.Pezzi;

            alb.Vita = AlberoVita;

        }
        else
        {
            alberoATerra = false;
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
