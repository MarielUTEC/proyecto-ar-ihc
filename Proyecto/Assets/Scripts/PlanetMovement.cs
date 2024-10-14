using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    private Vector3 randomRotationAxis;
    private float rotationSpeed;

    // Speed range for rotation (customize as needed)
    public float minSpeed = 10f;
    public float maxSpeed = 30f;

    void Start()
    {
        // Pick a random rotation axis
        randomRotationAxis = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;

        // Choose a random speed within the range
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        // Rotate the object based on the random axis and speed
        transform.Rotate(randomRotationAxis * rotationSpeed * Time.deltaTime);
    }
}
