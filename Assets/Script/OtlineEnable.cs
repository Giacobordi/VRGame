using UnityEngine;

public class OutlineEnable : MonoBehaviour
{
    public GameObject axe; // L'oggetto che contiene l'ascia
    public string playerTag = "Player"; // Tag assegnato al giocatore
    //public MonoBehaviour componentToToggle; // Il componente da attivare/disattivare
    public GameObject outlineer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            outlineer.GetComponent<Outline>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            outlineer.GetComponent<Outline>().enabled = true;
        }
    }
}
