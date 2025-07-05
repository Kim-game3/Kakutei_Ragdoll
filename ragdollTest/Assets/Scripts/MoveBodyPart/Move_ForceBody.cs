using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move_ForceBody : MonoBehaviour
{
    [SerializeField] Rigidbody _body;
    [SerializeField] float _power;
    [SerializeField] Transform _baseDirection;//Ç±ÇÍÇÃzï˚å¸Ç™ëOÇ∆Ç∑ÇÈ

    public void Input_Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;//É{É^ÉìÇâüÇµÇΩèuä‘î≠ìÆ

        Vector2 getVec = context.ReadValue<Vector2>();

        Move(getVec);
    }

    private void Move(Vector2 input)
    {
        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y);

        Quaternion lookForward = Quaternion.LookRotation(_baseDirection.forward);

        Vector3 forceDirection = lookForward * inputVec_3D;

        _body.AddForce(forceDirection*_power,ForceMode.VelocityChange);
    }
}
