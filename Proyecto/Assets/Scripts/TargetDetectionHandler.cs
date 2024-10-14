using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetDetectionHandler : MonoBehaviour
{
    public GameObject imagen;
    public AudioSource audioS;
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
            if (!audioS.isPlaying)
            {
                audioS.Play();
            }

            behaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
        else
        {
            if (audioS.isPlaying)
            {
                audioS.Stop();
            }
        }
    }
}
