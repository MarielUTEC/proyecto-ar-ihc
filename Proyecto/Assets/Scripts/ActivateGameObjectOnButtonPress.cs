using UnityEngine;
using UnityEngine.UI;

public class ActivateGameObjectOnButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
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

    private void OnButtonPress()
    {
        // Activa el GameObject especificado si no es nulo
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
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
