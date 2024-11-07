using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collezionaLegna : MonoBehaviour
{
    public GameObject albero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void raccogliLegna()
    {
        Destroy(albero);
    }
}
