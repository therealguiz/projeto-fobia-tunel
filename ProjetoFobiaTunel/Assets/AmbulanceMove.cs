using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMove : MonoBehaviour
{
    public float speed = 2f;         // Velocidade do carro

    void Update()
    {
        // Move o carro para frente SEMPRE
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
