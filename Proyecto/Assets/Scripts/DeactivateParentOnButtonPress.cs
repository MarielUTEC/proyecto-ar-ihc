using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateParentOnButtonPress : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        // Asigna el componente Button del GameObject actual
        button = GetComponent<Button>();

        // Verifica si el botón está asignado y agrega un listener al evento onClick
        if (button != null)
        {
            button.onClick.AddListener(OnButtonPress);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cuando otro objeto entre en el collider, asegúrate de que el botón esté activo
        if (button != null)
        {
            button.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si deseas que el botón se desactive al salir del área de colisión
        if (button != null)
        {
            button.gameObject.SetActive(false);
        }
    }

    private void OnButtonPress()
    {
        // Desactiva el GameObject padre del botón
        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        // Elimina el listener al destruir el objeto
        if (button != null)
        {
            button.onClick.RemoveListener(OnButtonPress);
        }
    }
}
