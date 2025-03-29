using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public AudioSource carFlashing;
    public AudioSource audioSource;
    public AudioSource audioSourceStop;
    public AudioSource audioLight;
    public float speed = 10f;  // Velocidade do carro
    public float deceleration = 2f;  // Taxa de desacelera��o
    public ParticleSystem smokeEffect;  // Sistema de part�culas da fuma�a
    private bool isSlowingDown = false;  // Flag para verificar se o carro est� desacelerando
    private bool hasStopped = false;  // Flag para verificar se o carro j� parou
    private float currentSpeed;

    void Start()
    {
        currentSpeed = speed;  // Come�a com a velocidade inicial
    }

    void Update()
    {
        // Se o carro est� desacelerando, diminui a velocidade at� parar
        if (isSlowingDown && currentSpeed > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            speed = Mathf.Max(currentSpeed, 0); // Garante que a velocidade n�o ser� negativa
        }

        // Move o carro para frente
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Se o carro parou, ative a fuma�a (apenas uma vez)
        if (hasStopped && smokeEffect != null && !smokeEffect.isPlaying)
        {
            smokeEffect.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o carro atingiu o trigger para come�ar a desacelera��o
        if (other.CompareTag("BreakdownTrigger"))
        {
            audioSource.Play();
            audioSourceStop.Stop();
            audioLight.Play();
            carFlashing.Play();
            isSlowingDown = true;  // Inicia a desacelera��o
            isSlowingDown = true;  // Inicia a desacelera��o
            StartCoroutine(StopCar());  // Inicia o processo para parar o carro
            
        }
    }

    private IEnumerator StopCar()
    {
        // Espera o tempo necess�rio para o carro parar
        yield return new WaitForSeconds(1f); // Ou qualquer tempo que voc� preferir
        speed = 0; // Para o carro completamente
        hasStopped = true; // Marca que o carro parou
    }
}
