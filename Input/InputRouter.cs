using Sources.Handlers;
using Sources.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRouter : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _movementBehaviour;
    [SerializeField] private ClickHandler _clickHandler;

    private PlayerInput _input;

    public IMovable Movable => (IMovable)_movementBehaviour;

    private void OnValidate()
    {
        if (_movementBehaviour is IMovable)
            return;


        _movementBehaviour = null;

        Debug.LogError("Value cannot be null");
    }

    private void OnEnable()
    {
        _input = new PlayerInput();
        _input.Enable();

        _input.Clicking.Enable();

        _input.Clicking.Click.performed += OnClickPerformed;
    }

    private void OnDisable()
    {
        _input.Clicking.Click.performed -= OnClickPerformed;
    }

    private void Update()
    {
        Movable.Turn(Input.mousePosition);
    }

    public void Disable()
    {
        _input.Clicking.Disable();
        _input.Disable();
        enabled = false;
    }

    private void OnClickPerformed(InputAction.CallbackContext obj)
    {
        _clickHandler.Click(Input.mousePosition);
    }
}
