using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject fadeQuad; // Referência ao Quad
    public float fadeDuration = 3.0f; // Duração do fade in

    private float currentAlpha = 1.0f; // Começa totalmente preto
    private Renderer quadRenderer;
    private Color quadColor;

    void Start()
    {
        // Obtém o componente Renderer do Quad
        quadRenderer = fadeQuad.GetComponent<Renderer>();

        // Define a cor inicial do Quad (totalmente preto)
        quadColor = quadRenderer.material.color;
        quadColor.a = currentAlpha;
        quadRenderer.material.color = quadColor;
    }

    void Update()
    {
        // Reduz a transparência ao longo do tempo
        if (currentAlpha > 0.0f)
        {
            currentAlpha -= Time.deltaTime / fadeDuration;
            currentAlpha = Mathf.Clamp01(currentAlpha); // Garante que o alpha fique entre 0 e 1

            // Atualiza a cor do Quad
            quadColor.a = currentAlpha;
            quadRenderer.material.color = quadColor;
        }
    }
}