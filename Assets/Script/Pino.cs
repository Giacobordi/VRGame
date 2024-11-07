using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pino : Albero_base
{
    // Start is called before the first frame update
    public Pino()
    {
        Nome = "Pino";
        Vita = 2;
        Pezzi = 1;
    }

}

public class Acero : Albero_base
{
    public Acero()
    {
        Nome = "Acero";
        Vita = 6;
        Pezzi = 2;
    }
}
