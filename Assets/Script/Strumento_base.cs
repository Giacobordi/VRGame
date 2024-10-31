using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strumento_base
{
    private string nome;

    private int danno;

    private int durabilita;

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

    public int Danno
    {
        get
        {
            return danno;
        }
        set
        {
            danno = value;
        }
    }

    public int Durabilita
    {
        get
        {
            return durabilita;
        }
        set
        {
            durabilita = value;
        }
    }

    public virtual void RiduciDurabilita(int durabilita)
    {
        void onTriggerEnter(Collider other)
        {
            if (other.CompareTag("albero"))
            {
                durabilita--;
            }
        }
    }
}
//sivallet