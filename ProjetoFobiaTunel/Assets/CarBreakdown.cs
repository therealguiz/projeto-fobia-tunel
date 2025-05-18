using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public AudioSource carFlashing;
    public AudioSource audioSource;
    public AudioSource audioSourceStop;
    public AudioSource audioLight;
    public float speed = 10f;  
    public float deceleration = 2f;  
    public ParticleSystem smokeEffect;  
    private bool isSlowingDown = false; 
    private bool hasStopped = false; 
    private float currentSpeed;
    

    void Start()
    {
        currentSpeed = speed;  
    }

    void Update()
    {
        
        if (isSlowingDown && currentSpeed > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            speed = Mathf.Max(currentSpeed, 0); 
        }

        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (hasStopped && smokeEffect != null && !smokeEffect.isPlaying)
        {
            smokeEffect.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("BreakdownTrigger"))
        {
            audioSource.Play();
            audioSourceStop.Stop();
            audioLight.Play();
            carFlashing.Play();
            isSlowingDown = true;  
            isSlowingDown = true;  
            StartCoroutine(StopCar()); 
            
        }
    }

    private IEnumerator StopCar()
    {
        
        yield return new WaitForSeconds(1f); 
        speed = 0; 
        hasStopped = true;
    }
}
