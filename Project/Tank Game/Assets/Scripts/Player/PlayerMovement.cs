using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    SpriteRenderer SpriteRenderer;
    Animator anim;

    [SerializeField]
    [Header("Movement Settings")]
    InputAction moveAction;
    InputAction rotateAction;
    public float speed;
    public float rotationSpeed;

    [SerializeField]
    [Header("Audio")]
    public AudioClip idle;
    public AudioClip moving;

    [SerializeField]
    [Header("Health")]
    public int maxHealth = 5;
    public int currentHealth;
    public bool invincible = false;
    public float invincibilityTime = 1f;
    public float invincibilityFlashDuration = 0.2f;

    [SerializeField]
    [Header("Score")]
    public int score = 0;

    [SerializeField]
    [Header("UI")]
    public TextMeshProUGUI scoreText, gameOverText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        moveAction = InputSystem.actions.FindAction("Move");

        rotateAction = InputSystem.actions.FindAction("Rotate");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        Vector2 movementInput = moveAction.ReadValue<Vector2>();
        //need to move in the way the ship is facing
        transform.Translate(Vector3.up * movementInput.y * speed * Time.deltaTime);
        transform.Translate(Vector3.right * movementInput.x * speed * Time.deltaTime);
    }

    public void Rotate()
    { 
        Vector2 rotationInput = rotateAction.ReadValue<Vector2>();
        GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation + rotationInput.x * rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we hit spikes, remove 1hp and run the post damage coroutine.
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1, true);
        }
    }

    void TakeDamage(int damageAmount, bool postDamageInvincibility)
    {
        currentHealth -= damageAmount;
        //UpdateUI();

        if (currentHealth <= 0)
        {
            StartCoroutine(Death());
            return;
        }

        if (postDamageInvincibility)
        {
            StartCoroutine(PostDamageInvincibility());
        }
    }

    IEnumerator PostDamageInvincibility()
    {
        // Set player to invincible
        invincible = true;
        float startTime = Time.time;
        // Turn on/off sprite renderer at intervals until the invincibility period ends.
        while ((Time.time - startTime) < invincibilityTime)
        {
            SpriteRenderer.enabled = !SpriteRenderer.enabled;
            yield return new WaitForSeconds(invincibilityFlashDuration);
        }
        SpriteRenderer.enabled = true;
        invincible = false;
    }
    IEnumerator Death()
    {
        // Make player invisible, and show game over text.
        SpriteRenderer.enabled = false;
        gameOverText.enabled = true;
        // Wait for 1 second to reload scene.
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
