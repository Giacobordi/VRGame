using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class troncoz : MonoBehaviour
{
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
        //outline = GetComponent<Outline>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mano"))
        {
            body.useGravity = true;
            //outline.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //body.useGravity = false;
        //outline.enabled = true;
    }

    //public void attivaGravita()
    //{
    //        body.useGravity = true;  
    //}

}

