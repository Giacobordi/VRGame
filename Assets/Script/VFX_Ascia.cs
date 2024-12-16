using UnityEngine;

public class VFX_Ascia : MonoBehaviour
{
    // Riferimento ai GameObjects figli che contengono gli effetti visivi
    public GameObject childGameObject1;
    public GameObject childGameObject2;

    // Riferimento ai ParticleSystem dei GameObjects figli
    private ParticleSystem particleSystem1;
    private ParticleSystem particleSystem2;

    void Start()
    {
        // Ottieni i componenti ParticleSystem dai GameObjects figli
        particleSystem1 = childGameObject1.GetComponent<ParticleSystem>();
        particleSystem2 = childGameObject2.GetComponent<ParticleSystem>();

        // Assicurati che gli effetti particelle siano inizialmente disattivati
        particleSystem1.Stop();
        particleSystem2.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Attiva il primo GameObject figlio e riproduce l'effetto visivo
        
        particleSystem1.Play();

        // Verifica se il GameObject con cui collide ha il tag "Albero"
        if (collision.gameObject.CompareTag("Albero"))
        {
            // Attiva il secondo GameObject figlio e riproduce l'effetto visivo
            
            particleSystem2.Play();
        }
    }
}
