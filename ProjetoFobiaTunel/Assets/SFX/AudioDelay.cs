using UnityEngine;

public class DelayedAudioPlay : MonoBehaviour
{
    public AudioSource audioSource;  // O áudio que você deseja tocar
    public float delayTime = 3f;     // Tempo de delay antes de começar o áudio
    public float fadeInTime = 2f;   // Tempo que o áudio vai levar para aumentar o volume até o nível máximo
    private float targetVolume = 0.082f; // Volume final do áudio
    private float initialVolume = 0f; // Volume inicial (começa baixo)
    private float currentTime = 0f;  // Controla o tempo de fade-in

    void Start()
    {
        audioSource.volume = initialVolume;  // Começa com o volume baixo
        Invoke("StartAudio", delayTime);    // Inicia o áudio após o delay
    }

    void StartAudio()
    {
        audioSource.Play();  // Toca o áudio
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            // Calcula o tempo atual do fade-in
            currentTime += Time.deltaTime;

            // Verifica se o tempo de fade-in não passou
            if (currentTime < fadeInTime)
            {
                // Aumenta o volume de forma gradual até o volume alvo
                audioSource.volume = Mathf.Lerp(initialVolume, targetVolume, currentTime / fadeInTime);
            }
            else
            {
                // Garante que o volume atinja o alvo final
                audioSource.volume = targetVolume;
            }
        }
    }
}
