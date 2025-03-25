using UnityEngine;

public class FadeOutAudio : MonoBehaviour
{
    public AudioSource audioSource; // Referência ao AudioSource
    public float fadeDuration = 5f; // Tempo que o fade durará
    public float delayTime = 2f; // Tempo antes do fade começar

    private bool isFadingOut = false;
    private float fadeTimer = 0f;

    void Start()
    {
        // Inicia o fade após o tempo de delay
        Invoke("StartFade", delayTime);
    }

    void Update()
    {
        // Se o fade estiver em andamento, diminui o volume
        if (isFadingOut)
        {
            fadeTimer += Time.deltaTime;
            float volume = Mathf.Lerp(0.082f, 0f, fadeTimer / fadeDuration);
            audioSource.volume = volume;

            // Quando o fade terminar, para o áudio
            if (fadeTimer >= fadeDuration)
            {
                audioSource.Stop();
                isFadingOut = false;
            }
        }
    }

    void StartFade()
    {
        isFadingOut = true;
    }
}
