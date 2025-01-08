using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pino : Albero_base
{
    // Start is called before the first frame update
    public Pino()
    {
        Nome = "Pino";
        Vita = 11;
        Pezzi = 4;
    }

}

public class Abete : Albero_base
{
    public Abete()
    {
        Nome = "Abete";
        Vita = 8;
        Pezzi = 3;
    }
}

public class Pioppo : Albero_base
{
    public Pioppo()
    {
        Nome = "Pioppo";
        Vita = 8;
        Pezzi = 2;
    }
}

public class Betulla : Albero_base
{
    public Betulla()
    {
        Nome = "Betulla";
        Vita = 6;
        Pezzi = 2;
    }
}

public class Frassino : Albero_base
{
    public Frassino()
    {
        Nome = "Frassino";
        Vita = 9;
        Pezzi = 3;
    }
}

public class Salice : Albero_base
{
    public Salice()
    {
        Nome = "Salice";
        Vita = 13;
        Pezzi = 3;
    }
}
