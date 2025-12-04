using UnityEngine;

public class enemyController : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    BoxCollider2D BoxCollider2D;


    [SerializeField]
    [Header("Enemy Settings")]
    public float eSpeed;
    public float eRotationSpeed;
    public float eMaxHealth = 5;
    public float eCurrentHealth;

    [SerializeField]
    [Header("Enemy Audio")]
    public AudioClip eIdle;
    public AudioClip eMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eCurrentHealth = eMaxHealth;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        death();
    }

    public void death()
    {
        if (eCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
