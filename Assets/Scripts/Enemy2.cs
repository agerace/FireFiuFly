using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public SoundManager soundManager;
    public GameManager gameManager;
    public AudioClip explosionSound;
    public AudioClip shotSound;

    public EnemyProjectile projectile;

    public float speed;
    void Start()
    {
        speed = 1f;
        Invoke("shoot", 1.5f);
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        Vector3 currentPosition = transform.position;


        float xNewValue = currentPosition.x + speed * deltaTime;
        float yNewValue = currentPosition.y + speed * deltaTime * -1;
        Debug.Log(currentPosition.y);
        transform.position = new Vector3(xNewValue, yNewValue, currentPosition.z);
    }

    private void shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        soundManager.playSound(shotSound);

        float timeToNextSpawn = Random.Range(0.5f, 1.2f);

        Invoke("shoot", timeToNextSpawn);
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
            gameManager.receivePoints(3);
        }
    }
}
