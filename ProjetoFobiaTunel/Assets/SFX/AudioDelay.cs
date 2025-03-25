using UnityEngine;

public class DelayedAudioPlay : MonoBehaviour
{
    public AudioSource audioSource;  // O �udio que voc� deseja tocar
    public float delayTime = 3f;     // Tempo de delay antes de come�ar o �udio
    public float fadeInTime = 2f;   // Tempo que o �udio vai levar para aumentar o volume at� o n�vel m�ximo
    private float targetVolume = 0.082f; // Volume final do �udio
    private float initialVolume = 0f; // Volume inicial (come�a baixo)
    private float currentTime = 0f;  // Controla o tempo de fade-in

    void Start()
    {
        audioSource.volume = initialVolume;  // Come�a com o volume baixo
        Invoke("StartAudio", delayTime);    // Inicia o �udio ap�s o delay
    }

    void StartAudio()
    {
        audioSource.Play();  // Toca o �udio
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            // Calcula o tempo atual do fade-in
            currentTime += Time.deltaTime;

            // Verifica se o tempo de fade-in n�o passou
            if (currentTime < fadeInTime)
            {
                // Aumenta o volume de forma gradual at� o volume alvo
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
