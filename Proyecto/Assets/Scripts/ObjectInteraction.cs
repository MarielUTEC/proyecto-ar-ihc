using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Vector3 initialTouchPosition;
    private Vector3 initialScale;
    private Quaternion initialRotation;
    private float initialDistance;

    // Asignar estos objetos desde el Inspector de Unity
    [SerializeField] public GameObject objectToDeactivateOnRotation; // Objeto para rotación
    [SerializeField] public GameObject objectToDeactivateOnScale; // Objeto para escala

    private bool isRotating = false;
    private bool isScaling = false;
    private float deactivateDelay = 2f; // Tiempo de espera antes de desactivar en segundos

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
                isRotating = true;
                StopAllCoroutines(); // Detener corrutinas previas si existen
                StartCoroutine(DeactivateObjectAfterDelay(objectToDeactivateOnRotation));
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                float deltaX = touch.deltaPosition.x;
                float rotationSpeed = 1f; // Ajusta la sensibilidad de la rotación
                transform.Rotate(0, -deltaX * rotationSpeed, 0, Space.World); // Rotar de manera incremental
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isRotating = false;
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
                isScaling = true;
                StopAllCoroutines(); // Detener corrutinas previas si existen
                StartCoroutine(DeactivateObjectAfterDelay(objectToDeactivateOnScale));
            }

            // Mover para detectar gestos de zoom (escalar)
            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved && isScaling)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleFactor = currentDistance / initialDistance;
                transform.localScale = initialScale * scaleFactor;
            }
            else if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
            {
                isScaling = false;
            }
        }
    }

    private IEnumerator DeactivateObjectAfterDelay(GameObject objectToDeactivate)
    {
        yield return new WaitForSeconds(deactivateDelay); // Esperar el tiempo especificado
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false); // Desactivar el objeto
        }
    }
}
