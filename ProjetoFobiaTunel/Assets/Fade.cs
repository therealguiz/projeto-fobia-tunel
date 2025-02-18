using UnityEngine;

public class FadeOnXPosition : MonoBehaviour
{
    public Transform targetObject;  // Objeto (carro) a ser monitorado
    public float triggerX;          // Posi��o X para iniciar o fade
    public Renderer fadeQuad;       // O Quad que cobre a tela
    public float fadeDuration = 2f; // Tempo de fade

    private bool hasTriggered = false;
    private float fadeTimer = 0f;
    private float initialX;  // Guarda a posi��o inicial do carro

    void Start()
    {
        // Guarda a posi��o X inicial do carro
        initialX = targetObject.position.x;

        // Certifique-se de que o Quad comece transparente
        if (fadeQuad != null)
        {
            Color color = fadeQuad.material.color;
            fadeQuad.material.color = new Color(color.r, color.g, color.b, 0);
        }
    }

    void Update()
    {
        // Verifica a dire��o do movimento e ativa o fade no momento certo
        if (!hasTriggered)
        {
            if (initialX > triggerX && targetObject.position.x <= triggerX) // Movendo de positivo para negativo
            {
                hasTriggered = true;
            }
            else if (initialX < triggerX && targetObject.position.x >= triggerX) // Movendo de negativo para positivo
            {
                hasTriggered = true;
            }
        }

        // Se o fade foi ativado, come�a a transi��o para preto
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

            // Atualiza a transpar�ncia do Quad
            Color color = fadeQuad.material.color;
            fadeQuad.material.color = new Color(color.r, color.g, color.b, alpha);
        }
    }
}