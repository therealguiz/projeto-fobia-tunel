using UnityEngine;
using System.Collections;

public class CarStop : MonoBehaviour
{
    public float speed = 5f; // Velocidade do carro
    public float stopDuration = 3f; // Tempo parado antes de continuar
    private bool isStopped = false;

    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrafficStop"))
        {
            StartCoroutine(StopCar());

            // Desativa o collider do trigger para evitar ativações duplas
            other.GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator StopCar()
    {
        isStopped = true;
        yield return new WaitForSeconds(stopDuration);
        isStopped = false;
    }
}
