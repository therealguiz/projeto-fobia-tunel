using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public AudioSource carFlashing;
    public AudioSource audioSource;
    public AudioSource audioSourceStop;
    public AudioSource audioLight;
    public float speed = 10f;  // Velocidade do carro
    public float deceleration = 2f;  // Taxa de desaceleração
    public ParticleSystem smokeEffect;  // Sistema de partículas da fumaça
    private bool isSlowingDown = false;  // Flag para verificar se o carro está desacelerando
    private bool hasStopped = false;  // Flag para verificar se o carro já parou
    private float currentSpeed;

    void Start()
    {
        currentSpeed = speed;  // Começa com a velocidade inicial
    }

    void Update()
    {
        // Se o carro está desacelerando, diminui a velocidade até parar
        if (isSlowingDown && currentSpeed > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            speed = Mathf.Max(currentSpeed, 0); // Garante que a velocidade não será negativa
        }

        // Move o carro para frente
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Se o carro parou, ative a fumaça (apenas uma vez)
        if (hasStopped && smokeEffect != null && !smokeEffect.isPlaying)
        {
            smokeEffect.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o carro atingiu o trigger para começar a desaceleração
        if (other.CompareTag("BreakdownTrigger"))
        {
            audioSource.Play();
            audioSourceStop.Stop();
            audioLight.Play();
            carFlashing.Play();
            isSlowingDown = true;  // Inicia a desaceleração
            isSlowingDown = true;  // Inicia a desaceleração
            StartCoroutine(StopCar());  // Inicia o processo para parar o carro
            
        }
    }

    private IEnumerator StopCar()
    {
        // Espera o tempo necessário para o carro parar
        yield return new WaitForSeconds(1f); // Ou qualquer tempo que você preferir
        speed = 0; // Para o carro completamente
        hasStopped = true; // Marca que o carro parou
    }
}
