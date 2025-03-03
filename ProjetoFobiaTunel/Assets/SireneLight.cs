using UnityEngine;
using System.Collections;

public class SireneLight : MonoBehaviour
{
    public Light sireneLight;
    public float blinkInterval = 0.5f;
    private bool isRed = true;

    void Start()
    {
        StartCoroutine(BlinkLight());
    }

    IEnumerator BlinkLight()
    {
        while (true)
        {
            isRed = !isRed;
            sireneLight.color = isRed ? Color.red : Color.blue;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
