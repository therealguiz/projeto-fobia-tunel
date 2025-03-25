using UnityEngine;

public class AmbulanceSound : MonoBehaviour
{
    public AudioSource sirenAudio;  // Refer�ncia ao AudioSource da sirene

    void Start()
    {
        // Verifique se o AudioSource est� configurado corretamente
        if (sirenAudio == null)
        {
            Debug.LogError("O AudioSource n�o est� atribu�do!");
            return;
        }

        // Iniciar o som da sirene assim que a ambul�ncia come�ar
        sirenAudio.loop = true;  // Tornar o �udio repetitivo
        sirenAudio.Play();  // Inicia o �udio da sirene
    }

    
}
