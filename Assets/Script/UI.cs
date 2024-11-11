using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public static int contatore_pezzi;
    [SerializeField] TextMeshProUGUI testoUI;
    // Start is called before the first frame update
    void Start()
    {
        contatore_pezzi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("pezzi: "+ contatore_pezzi);
        //testoUI.text = contatore_pezzi.ToString();

    }

    public void Start_Game()
    {
        //Debug.Log("porcodio");
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit_game()
    {

    }

    public void Resume()
    {
        
    }
}
