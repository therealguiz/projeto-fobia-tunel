using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 2f;         // Velocidade do carro
    public float turnSpeed = 20f;    // Velocidade da curva
    public float turnStartTime = 3f; // Tempo antes de começar a virar
    public float turnDuration = 2f;  // Quanto tempo a curva dura
    public float finalRotationY = -30f; // Ângulo exato após a curva

    private bool isTurning = false;  // Indica se o carro começou a virar
    private bool hasFinishedTurning = false; // Indica se a curva já foi concluída
    private float turnEndTime;       // Tempo em que o carro deve parar de virar

    void Update()
    {
        // Move o carro para frente SEMPRE
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Verifica se está na hora de começar a curva
        if (Time.time >= turnStartTime && !isTurning && !hasFinishedTurning)
        {
            isTurning = true;
            turnEndTime = Time.time + turnDuration; // Define quando a curva vai parar
        }

        // Se estiver no período da curva, rotaciona o carro
        if (isTurning && Time.time <= turnEndTime)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (isTurning) // Quando a curva termina
        {
            isTurning = false; // Para de virar
            hasFinishedTurning = true; // Marca que a curva já foi feita
            transform.eulerAngles = new Vector3(0, finalRotationY, 0); // Define manualmente o ângulo Y
        }
    }
}
