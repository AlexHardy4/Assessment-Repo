using UnityEngine;


public class BulletScript : MonoBehaviour
{
    [SerializeField] enemyController enemy;

    private Vector3 mousePos;
    private Camera MainCam;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    public float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot + 90);
    }

    //code that when the bullet hits something it gets destroyed its force set to 0 and plays a sound and explosion animation
    //when the bullet hits an enemy it deals damage to the enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyController enemy = collision.gameObject.GetComponent<enemyController>();
            if (enemy != null)
            {
                enemy.eCurrentHealth -= 1;
            }
            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
