using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    private bool isFacingRight = true;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(new Vector3(newAim.x, newAim.y, transform.position.z - _camera.transform.position.z));
        Vector2 direction = (worldPos - (Vector2)transform.position).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (direction.x < 0 && isFacingRight)
            {
                FlipCharacter();
            }
            else if (direction.x > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
        }
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
