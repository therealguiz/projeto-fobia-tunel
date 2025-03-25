using UnityEngine;

public class FadeOutAudio : MonoBehaviour
{
    public AudioSource audioSource; // Refer�ncia ao AudioSource
    public float fadeDuration = 5f; // Tempo que o fade durar�
    public float delayTime = 2f; // Tempo antes do fade come�ar

    private bool isFadingOut = false;
    private float fadeTimer = 0f;

    void Start()
    {
        // Inicia o fade ap�s o tempo de delay
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

            // Quando o fade terminar, para o �udio
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
