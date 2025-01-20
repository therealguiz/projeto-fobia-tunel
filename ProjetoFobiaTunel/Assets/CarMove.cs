using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 2f;         // Velocidade do carro
    public float turnSpeed = 20f;    // Velocidade da curva
    public float turnStartTime = 3f; // Tempo antes de come�ar a virar
    public float turnDuration = 2f;  // Quanto tempo a curva dura
    public float finalRotationY = -30f; // �ngulo exato ap�s a curva

    private bool isTurning = false;  // Indica se o carro come�ou a virar
    private bool hasFinishedTurning = false; // Indica se a curva j� foi conclu�da
    private float turnEndTime;       // Tempo em que o carro deve parar de virar

    void Update()
    {
        // Move o carro para frente SEMPRE
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Verifica se est� na hora de come�ar a curva
        if (Time.time >= turnStartTime && !isTurning && !hasFinishedTurning)
        {
            isTurning = true;
            turnEndTime = Time.time + turnDuration; // Define quando a curva vai parar
        }

        // Se estiver no per�odo da curva, rotaciona o carro
        if (isTurning && Time.time <= turnEndTime)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (isTurning) // Quando a curva termina
        {
            isTurning = false; // Para de virar
            hasFinishedTurning = true; // Marca que a curva j� foi feita
            transform.eulerAngles = new Vector3(0, finalRotationY, 0); // Define manualmente o �ngulo Y
        }
    }
}
