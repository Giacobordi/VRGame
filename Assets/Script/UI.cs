using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public static int contatore_pezzi;
    [SerializeField] TextMeshProUGUI pezzo1;
    [SerializeField] TextMeshProUGUI pezzo2;
    [SerializeField] TextMeshProUGUI pezzo3;
    [SerializeField] TextMeshProUGUI pezzo4;
    
    public int pino_abete;
    public int salice;
    public int betulla;
    public int frassino_pioppo;
    //[SerializeField] TextMeshProUGUI testoUI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.pino_abete = ScoreHandler.playerPrefPA;
        this.salice = ScoreHandler.playerPrefS;
        this.betulla = ScoreHandler.playerPrefB;
        this.frassino_pioppo = ScoreHandler.playerPrefFP;
        
        pezzo1.text = this.pino_abete.ToString();
        pezzo2.text = this.salice.ToString();
        pezzo3.text = this.betulla.ToString();
        pezzo4.text = this.frassino_pioppo.ToString();
    }

    public void Start_Game()
    {
        //Debug.Log("porcodio");
        SceneManager.LoadScene("GameScene");
    }

    public void Exit_game()
    {

    }

    public void Resume()
    {
        
    }
}
