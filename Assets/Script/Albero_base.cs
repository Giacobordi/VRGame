using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Albero_base
{
    private string nome;
    private int vita;
    private int pezzi;

    
    public string Nome
    {
        get
        {
            return nome;
        }
        set
        {
            nome = value;
        }
    }
    public int Vita
    {
        get
        {
            return vita;
        }
        set
        {
            vita = value;
        }
    }

    public int Pezzi
    {
        get
        {
            return pezzi;
        }
        set
        {
            pezzi = value;
        }
    }

    public void decrementaVita( int attaccoAscia)
    {
        this.vita -= attaccoAscia;
       
    }

}
