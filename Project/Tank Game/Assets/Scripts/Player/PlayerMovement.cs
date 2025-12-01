using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
}
