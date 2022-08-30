using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = 11f;
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        Vector3 currentPosition = transform.position;

        float yNewValue = currentPosition.y + speed * deltaTime * 1;

        transform.position = new Vector3(currentPosition.x, yNewValue, currentPosition.z);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
