using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierShip : MonoBehaviour
{
    float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        Vector3 currentPosition = transform.position;

        float yNewValue = currentPosition.y + speed * deltaTime * -1;

        transform.position = new Vector3(currentPosition.x, yNewValue, currentPosition.z);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
