using UnityEngine;
using System.Collections;

public class CarStop : MonoBehaviour
{
    public float speed = 5f; // Velocidade do carro
    public float stopDuration = 3f; // Tempo parado antes de continuar
    private bool isStopped = false;
    private bool hasActivated = false;

    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("TrafficStop"))
        {
            hasActivated = true;
            StartCoroutine(StopCar());
        }
    }

    IEnumerator StopCar()
    {
        isStopped = true;
        yield return new WaitForSeconds(stopDuration);
        isStopped = false;
    }
}
