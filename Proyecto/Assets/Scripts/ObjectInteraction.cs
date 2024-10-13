using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Vector3 initialTouchPosition;
    private Vector3 initialScale;
    private Quaternion initialRotation;
    private float initialDistance;
    private float initialAngle;

    void Update()
    {
        // Rotar el objeto con un dedo (izquierda a derecha)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch.position;
                initialRotation = transform.rotation;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x;
                float rotationSpeed = 0.2f; // Ajusta la sensibilidad de la rotación
                transform.rotation = initialRotation * Quaternion.Euler(0, -deltaX * rotationSpeed, 0);
            }
        }

        // Escalar el objeto con dos dedos
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Inicializar valores cuando ambos toques comienzan
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialScale = transform.localScale;
                initialDistance = Vector2.Distance(touch1.position, touch2.position);
            }

            // Mover para detectar gestos de zoom (escalar)
            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleFactor = currentDistance / initialDistance;
                transform.localScale = initialScale * scaleFactor;
            }
        }
    }
}
