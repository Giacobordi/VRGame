using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class troncoz : MonoBehaviour
{
    public Rigidbody body;

    public bool diocane;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tronco"))
        {
            diocane = true;
            body.isKinematic = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Tronco"))
        {
            body.isKinematic = false;
            diocane = false;
        }
    }

    //public void attivaGravita()
    //{
    //        body.useGravity = true;  
    //}

}

