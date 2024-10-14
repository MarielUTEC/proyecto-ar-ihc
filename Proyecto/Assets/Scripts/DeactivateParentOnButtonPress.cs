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

        // Verifica si el bot�n est� asignado y agrega un listener al evento onClick
        if (button != null)
        {
            button.onClick.AddListener(OnButtonPress);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cuando otro objeto entre en el collider, aseg�rate de que el bot�n est� activo
        if (button != null)
        {
            button.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si deseas que el bot�n se desactive al salir del �rea de colisi�n
        if (button != null)
        {
            button.gameObject.SetActive(false);
        }
    }

    private void OnButtonPress()
    {
        // Desactiva el GameObject padre del bot�n
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
