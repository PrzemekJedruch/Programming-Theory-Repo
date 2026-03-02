using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 200f;
    [SerializeField] private Transform cameraPivot;

    // The xRotation variable is used to keep track of the player's vertical rotation (looking up and down). It is modified based on mouse input and clamped to prevent the player from looking too far up or down.
    private float xRotation = 0f;
    // The rb variable is used to reference the Rigidbody component attached to the player GameObject. This is necessary for rotating the player based on mouse input using physics.
    private Rigidbody rb;
    // The mouseXInput variable is used to store the horizontal mouse input (looking left and right). It is calculated based on the mouse input and used to rotate the player in the MouseRotation method.
    private float mouseXInput;
    

    void Start()
    {
        // ENKAPSULASION: The StartElements method is responsible for initializing the necessary components and setting up the cursor lock state. By calling this method in Start, we ensure that all the required elements are properly initialized when the game starts.
        StartElements();
    }

    void Update()
    {
        // ENKAPSULASION: The MousePosition method is responsible for calculating the player's rotation based on mouse input. By calling this method in Update, we ensure that the player's rotation is updated every frame based on the player's mouse movement.
        MousePosition();
    }

    void FixedUpdate()
    {
        // ENKAPSULASION: The MouseRotation method is responsible for rotating the player based on mouse input. By calling this method in FixedUpdate, we ensure that the player's rotation is consistent with the physics engine's update cycle.
        MouseRotation();
    }

    private void MousePosition()
    {
        mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void MouseRotation()
    {
        Quaternion rotation = Quaternion.Euler(0f, rb.rotation.eulerAngles.y + mouseXInput, 0f);
        rb.MoveRotation(rotation);
    }

    private void StartElements()
    {
        // This method is not currently used, but it can be implemented to handle additional initialization logic if needed.
        // For example, you could initialize other components or set up references here.

        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
}