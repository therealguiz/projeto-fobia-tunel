using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public GameObject fadeQuad; 
    public float fadeDuration = 2.0f; 
    public float delayBeforeFade = 5.0f; 
    public string nextSceneName; 

    private float currentAlpha = 0.0f;
    private bool isFading = false;
    private float timer = 0.0f;
    private Material quadMaterial;

    void Start()
    {
        
        quadMaterial = fadeQuad.GetComponent<Renderer>().material;

        
        Color color = quadMaterial.color;
        color.a = 0.0f;
        quadMaterial.color = color;
    }

    void Update()
    {
        if (!isFading)
        {
            timer += Time.deltaTime;
            if (timer >= delayBeforeFade)
            {
                isFading = true;
                timer = 0.0f; 
            }
        }

        
        if (isFading)
        {
            currentAlpha += Time.deltaTime / fadeDuration;
            currentAlpha = Mathf.Clamp01(currentAlpha);

            
            Color color = quadMaterial.color;
            color.a = currentAlpha;
            quadMaterial.color = color;

            
            if (currentAlpha >= 1.0f)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}