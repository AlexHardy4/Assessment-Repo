using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    enum State
    {
        Patrol,
        Chase,
        Shoot
    }
    State state = State.Patrol;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Patrol)
        {
            //Patrol();
        }
        else if (state == State.Chase)
        {
            //Chase();
        }
        else if (state == State.Shoot)
        {
            state = State.Patrol;
            //Shoot();
        }
    }
}
