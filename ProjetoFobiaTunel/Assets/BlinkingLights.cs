using System.Collections;
using UnityEngine;

public class BlinkingLights : MonoBehaviour
{
    public Light[] lights; // Array de luzes do túnel
    public float minBlinkInterval = 0.5f; // Tempo mínimo entre piscadas
    public float maxBlinkInterval = 2f; // Tempo máximo entre piscadas
    public bool randomBlink = true; // Se as luzes piscam aleatoriamente

    void Start()
    {
        foreach (Light light in lights)
        {
            StartCoroutine(BlinkLight(light));
        }
    }

    IEnumerator BlinkLight(Light light)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minBlinkInterval, maxBlinkInterval));
            light.enabled = !light.enabled; // Liga/desliga a luz
        }
    }
}
