using UnityEngine;
using System.Collections;

public class TrafficCar : MonoBehaviour
{
    public float speed = 5f; // Velocidade dos carros do trânsito
    public float startDelay = 3f; // Tempo parado antes de começar a andar

    void Start()
    {
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;
        }
    }
}
