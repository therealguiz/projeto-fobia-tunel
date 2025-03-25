using System.Collections;
using UnityEngine;

public class TrafficSfxTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2f; // Tempo do fade in (em segundos)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrafficSFX"))
        {
            if (audioSource != null)
            {
                StartCoroutine(FadeInSound());
            }
            else
            {
                Debug.LogError("AudioSource não está atribuído!");
            }
        }
    }

    IEnumerator FadeInSound()
    {
        float startVolume = 0f;
        float targetVolume = 1f; // Volume máximo do áudio
        float elapsedTime = 0f;

        audioSource.volume = startVolume;
        audioSource.Play(); // Inicia o som com volume zero

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume; // Garante que o volume final seja o desejado
    }
}

