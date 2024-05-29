using UnityEngine;

public class PInputManager : MonoBehaviour
{
    InputManager playerinput;

    private PlayerController controller;

    private Vector2 _movement;
    public Vector2 Movement { get { return _movement; } private set { _movement = value; } }

    private void Awake()
    {
        playerinput = new InputManager();
        controller = GetComponent<PlayerController>();

    }
    private void OnEnable()
    {
        playerinput.Enable();
        playerinput.Locomotion.Moving.performed += (val) => Movement = val.ReadValue<Vector2>();
        playerinput.Locomotion.Jump.performed += (val) => controller.Jump();

    }

    private void OnDisable()
    {

        playerinput.Locomotion.Moving.performed -= (val) => Movement = val.ReadValue<Vector2>();
        playerinput.Locomotion.Jump.performed -= (val) => controller.Jump();
        playerinput.Disable();
    }

}
