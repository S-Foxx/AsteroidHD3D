using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementSettings settings; // Reference to the player movement settings

    private Rigidbody rb;
    private Camera mainCamera;
    private Vector3 screenBottomLeft;
    private Vector3 screenTopRight;
    private float rotationInput;
    private bool isThrusting;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Lock X and Z rotation
        rb.drag = 0.5f; // Add some drag to simulate space friction

        mainCamera = Camera.main;
        CalculateScreenBounds();
    }

    private void Update()
    {
        rotationInput = Input.GetAxis("Horizontal");
        isThrusting = Input.GetKey(KeyCode.W);

        HandleWrapAround();
    }

    private void FixedUpdate()
    {
        HandleRotation();
        HandleThrust();
    }

    private void CalculateScreenBounds()
    {
        screenBottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.y));
        screenTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.y));
    }

    private void HandleRotation()
    {
        if (rotationInput != 0)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotationInput * settings.rotationSpeed * Time.deltaTime, 0));
        }
    }

    private void HandleThrust()
    {
        if (isThrusting)
        {
            rb.AddForce(transform.forward * settings.thrustPower);

            if (rb.velocity.magnitude > settings.maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * settings.maxSpeed;
            }
        }
    }

    private void HandleWrapAround()
    {
        Vector3 newPosition = transform.position;

        if (newPosition.x > screenTopRight.x) newPosition.x = screenBottomLeft.x;
        else if (newPosition.x < screenBottomLeft.x) newPosition.x = screenTopRight.x;

        if (newPosition.z > screenTopRight.z) newPosition.z = screenBottomLeft.z;
        else if (newPosition.z < screenBottomLeft.z) newPosition.z = screenTopRight.z;

        transform.position = newPosition;
    }
}
