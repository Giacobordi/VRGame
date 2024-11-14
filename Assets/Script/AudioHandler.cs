using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    Collider soundEnter;
    AudioSource soundSource;
    // Start is called before the first frame update
    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        soundEnter = GetComponent<Collider>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Albero"))
        {
            Debug.Log("diocane");
            soundSource.Play();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
