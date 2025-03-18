using UnityEngine;
using System.Collections;

public class TrafficCar : MonoBehaviour
{
    public float speed = 5f; // Velocidade dos carros do tr�nsito
    public float startDelay = 3f; // Tempo parado antes de come�ar a andar

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
