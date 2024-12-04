using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshChanger : MonoBehaviour
{
    [SerializeField] public MeshFilter modeYouWantToChange;

    [SerializeField] public Mesh myMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ascia"))
        {
            modeYouWantToChange.mesh = myMesh;
        }
    }
}
