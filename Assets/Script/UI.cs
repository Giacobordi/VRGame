using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public static int contatore_pezzi;
    [SerializeField] TextMeshProUGUI pezzoPA;
    [SerializeField] TextMeshProUGUI pezzoS;
    [SerializeField] TextMeshProUGUI pezzoB;
    [SerializeField] TextMeshProUGUI pezzoFP;
    
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
        
        pezzoPA.text = this.pino_abete.ToString();
        pezzoS.text = this.salice.ToString();
        pezzoB.text = this.betulla.ToString();
        pezzoFP.text = this.frassino_pioppo.ToString();
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
