using System;
using UnityEngine;

public class OutlineEnable : MonoBehaviour
{
    public GameObject axe; // L'oggetto che contiene l'ascia
    public string playerTag = "Player"; // Tag assegnato al giocatore
    public MonoBehaviour componentToToggle; // Il componente da attivare/disattivare

    public void Start()
    {
        componentToToggle.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (componentToToggle != null)
            {
                componentToToggle.enabled = false; // Disattiva il componente
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (componentToToggle != null)
            {
                componentToToggle.enabled = true; // Riattiva il componente
            }
        }
    }
}
