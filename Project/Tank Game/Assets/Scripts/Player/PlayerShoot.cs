using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;
    public Transform bullet;
    public Transform bulletTransform;
    public bool canShoot;
    private float timer;
    public float shootDelay;

    [SerializeField]
    InputAction shootAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ -90);

        if(!canShoot)
        {
            timer += Time.deltaTime;
            if(timer > shootDelay)
            {
                canShoot = true;
                timer = 0f;
            }
        }

        if (shootAction.WasPerformedThisFrame() && canShoot)
        {
            canShoot = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

}
