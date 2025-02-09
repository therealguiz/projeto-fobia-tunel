using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;
    public float rotationSpeedMultiplier = 200f; 

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position; 
    }

    void Update()
    {
        // Calcula a velocidade com base na dist�ncia percorrida por frame
        float speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position; 

        // Calcula a rota��o das rodas
        float rotationAmount = speed * rotationSpeedMultiplier * Time.deltaTime;

        // Aplica a rota��o nas rodas
        RotateWheel(frontLeftWheel, rotationAmount);
        RotateWheel(frontRightWheel, rotationAmount);
        RotateWheel(rearLeftWheel, rotationAmount);
        RotateWheel(rearRightWheel, rotationAmount);
    }

    void RotateWheel(Transform wheel, float rotationAmount)
    {
        if (wheel != null)
        {
            wheel.Rotate(rotationAmount, 0, 0, Space.Self);
        }
    }
}
