using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Movement tuning (editable in Inspector)
    public float speed = 5.0f;
    public float turnSpeed = 100f;
    // Input System actions
    public InputAction MoveAction;
    // Current input value (x = left/right, y= forward/back), kept private for internal use.
    public Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // MoveAction starts receiving input.
        MoveAction.Enable();
    }

    

    // Update is called once per frame
    void Update()
    {
        // Read 2D vector from MoveAction
        moveInput = MoveAction.ReadValue<Vector2>();

        // Move forward/backward along z using y component
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        // Rotate around local Y using the x component.
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);
    }
}
