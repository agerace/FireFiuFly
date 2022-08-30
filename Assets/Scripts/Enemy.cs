using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SoundManager soundManager;
    public GameManager gameManager;
    public AudioClip explosionSound;

    public float speed;
    float xDirection;
    void Start()
    {
        speed = Random.Range(3.5f, 7.5f);
        xDirection = Random.Range(-1f, 1f);
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        Vector3 currentPosition = transform.position;


        float xNewValue = currentPosition.x + speed * deltaTime * xDirection;
        float yNewValue = currentPosition.y + speed * deltaTime * -1;

        transform.position = new Vector3(xNewValue, yNewValue, currentPosition.z);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            soundManager.playSound(explosionSound);
            gameManager.receivePoints(1);
        }
    }

}
