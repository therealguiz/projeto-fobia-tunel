using UnityEngine;

public class AmbulanceSound : MonoBehaviour
{
    public AudioSource sirenAudio;  // Referência ao AudioSource da sirene

    void Start()
    {
        // Verifique se o AudioSource está configurado corretamente
        if (sirenAudio == null)
        {
            Debug.LogError("O AudioSource não está atribuído!");
            return;
        }

        // Iniciar o som da sirene assim que a ambulância começar
        sirenAudio.loop = true;  // Tornar o áudio repetitivo
        sirenAudio.Play();  // Inicia o áudio da sirene
    }

    
}
