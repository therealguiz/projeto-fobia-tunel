using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public GameObject fadeQuad; // Referência ao Quad
    public float fadeDuration = 2.0f; // Duração do fade out
    public float delayBeforeFade = 5.0f; // Tempo de espera antes de iniciar o fade
    public string nextSceneName; // Nome da próxima cena

    private float currentAlpha = 0.0f;
    private bool isFading = false;
    private float timer = 0.0f;
    private Material quadMaterial;

    void Start()
    {
        // Obtém o material do Quad
        quadMaterial = fadeQuad.GetComponent<Renderer>().material;

        // Garante que o Quad comece transparente
        Color color = quadMaterial.color;
        color.a = 0.0f;
        quadMaterial.color = color;
    }

    void Update()
    {
        // Conta o tempo antes de iniciar o fade
        if (!isFading)
        {
            timer += Time.deltaTime;
            if (timer >= delayBeforeFade)
            {
                isFading = true;
                timer = 0.0f; // Reseta o timer para o fade
            }
        }

        // Executa o fade out
        if (isFading)
        {
            currentAlpha += Time.deltaTime / fadeDuration;
            currentAlpha = Mathf.Clamp01(currentAlpha);

            // Atualiza a transparência do material do Quad
            Color color = quadMaterial.color;
            color.a = currentAlpha;
            quadMaterial.color = color;

            // Quando o fade out estiver completo, troca de cena
            if (currentAlpha >= 1.0f)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}