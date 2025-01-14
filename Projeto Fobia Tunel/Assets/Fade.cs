using UnityEngine;

public class FadeOnPosition : MonoBehaviour
{
    public Transform targetObject;  // Objeto a ser monitorado
    public Vector3 triggerPosition; // Posição para iniciar o fade
    public Renderer fadeQuad;       // O Quad que cobre a tela
    public float fadeDuration = 2f; // Tempo de fade

    private bool hasTriggered = false;
    private float fadeTimer = 0f;

    void Start()
    {
        // Certifique-se de que o Quad comece transparente
        if (fadeQuad != null)
        {
            Color color = fadeQuad.material.color;
            fadeQuad.material.color = new Color(color.r, color.g, color.b, 0);
        }
    }

    void Update()
    {
        if (!hasTriggered && Vector3.Distance(targetObject.position, triggerPosition) < 0.1f)
        {
            hasTriggered = true;
        }

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

            // Atualiza a transparência do Quad
            Color color = fadeQuad.material.color;
            fadeQuad.material.color = new Color(color.r, color.g, color.b, alpha);
        }
    }
}
