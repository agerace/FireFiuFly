using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SoundManager soundManager;
    public GameManager gameManager;

    public Animator animator;

    public bool isInvincible = false;
    public int livesRemaining = 3;
    public bool isDead = false;
    public AudioClip shotSound;
    public AudioClip explosionSound;
    public float speed;
    public PlayerProjectile projectile;
    private float yMovementBlock = 0;
    private float xMovementBlock = 0;

    void Start()
    {
        transform.position = new Vector3(0, -3.5f, 0);
        speed = 8f;
    }

    void Update()
    {
        if (isDead) { return; }

        float deltaTime = Time.deltaTime;

        float xDirection = Input.GetAxisRaw("Horizontal");
        if (xDirection < 0 && xMovementBlock > 0)
        {
            xDirection = 0;
        }else if (xDirection > 0 && xMovementBlock < 0)
        {
            xDirection = 0;
        }
            float yDirection = Input.GetAxisRaw("Vertical");

        if (yDirection < 0 && yMovementBlock > 0)
        {
            yDirection = 0;
        }
        else if (yDirection > 0 && yMovementBlock < 0)
        {
            yDirection = 0;
        }

        Vector3 currentPosition = transform.position;
        float xNewValue = currentPosition.x + speed * deltaTime * xDirection;
        float yNewValue = currentPosition.y + speed * deltaTime * yDirection;
        transform.position = new Vector3(xNewValue, yNewValue, currentPosition.z);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            soundManager.playSound(shotSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead || isInvincible) { return; }
        if (collision.tag == "Enemy" || collision.tag == "EnemyProjectile")
        {
            isHit();
        }
    }

    private void isHit()
    {
        livesRemaining--;
        gameManager.playerIsHitted(livesRemaining);
        if (livesRemaining == 0)
        {
            isDead = true;
            animator.SetBool("isDead", isDead);
            soundManager.playSound(explosionSound);
            Invoke("die", 1);
        }else
        {
            changePlayerState();
            Invoke("changePlayerState", 2);
        }
    }

    private void changePlayerState()
    {
        isInvincible = !isInvincible;
    }
    private void die()
    {
        Destroy(gameObject.GetComponent<Renderer>());
        Invoke("goToMenu", 2);
    }
    private void goToMenu()
    {
        Destroy(gameObject);
        gameManager.endGame();
    }
}
