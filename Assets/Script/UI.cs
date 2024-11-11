using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static int contatore_pezzi;
    // Start is called before the first frame update
    void Start()
    {
        contatore_pezzi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("pezzi: "+ contatore_pezzi);
    }

    public void Start_Game()
    {

    }

    public void Exit_game()
    {

    }

    public void Resume()
    {
        
    }
}
