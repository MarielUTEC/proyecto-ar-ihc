using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetDetectionHandler : MonoBehaviour
{
    public GameObject imagen;
    public AudioSource audio;
    private void Start()
    {
        var observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // Verifica si se ha detectado el target
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            imagen.SetActive(false);
            audio.Play();

            behaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
