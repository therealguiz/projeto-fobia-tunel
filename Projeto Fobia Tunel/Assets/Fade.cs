using UnityEngine;
using UnityEngine.UI;

public class VRFadeOnPosition : MonoBehaviour
{
    public Transform targetObject;  // Objeto a ser monitorado
    public Vector3 triggerPosition; // Posição para iniciar o fade
    public Canvas fadeCanvas;       // Canvas no mundo VR
    public Image fadePanel;         // Painel preto para o fade
    public float fadeDuration = 2f; // Duração do fade

    private bool hasTriggered = false;
    private float fadeTimer = 0f;

    void Update()
    {
        // Verifica se o objeto chegou na posição desejada
        if (!hasTriggered && Vector3.Distance(targetObject.position, triggerPosition) < 0.1f)
        {
            hasTriggered = true;
        }

        // Executa o fade
        if (hasTriggered)
        {
            FadeToBlack();
        }
    }

    void FadeToBlack()
    {
        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
        }
    }
}
