using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    Vector3 initialPosition;
    public float speed = 3f;

    private void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        float deltaTime = Time.deltaTime;

        Vector3 currentPosition = transform.position;

        float yNewValue = currentPosition.y + speed * deltaTime * -1;

        transform.position = new Vector3(currentPosition.x, yNewValue, currentPosition.z);
    }

    private void OnBecameInvisible()
    {
        transform.position = initialPosition;
    }
}
