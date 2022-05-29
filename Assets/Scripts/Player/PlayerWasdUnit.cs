using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWasdUnit : PlayerUnit
{
    [SerializeField] CameraRig followingCamera;

    private void Awake()
    {
        if (followingCamera == null)
            followingCamera = Camera.main.GetComponent<CameraRig>();

        OnControlledUnitChange += UpdateCameraTarget;
    }

    private void UpdateCameraTarget(Unit unit) 
    {
        if (unit == null)
            return;

        followingCamera.focusPoint = unit.transform;
        followingCamera.focusMoved = true;
    }


    [SerializeField] private Vector3 inputDirection;

    [SerializeField] private MovementInput processedInput => _processedInput;
    
    private MovementInput _processedInput;

    void Update()
    {
        ProcessMovementInput();
        MoveUnit();
    }

    private void MoveUnit()
    {
        if (!controlledUnit)
            return;

        var movement = controlledUnit.GetComponent<Movement>();
        _processedInput.cameraBasis = followingCamera.transform;
        movement.SetVelocity(_processedInput);
        followingCamera.focusMoved = true;
    }

    private void ProcessMovementInput()
    {
        inputDirection = Vector3.zero;
        inputDirection += Convert.ToByte(Input.GetKey(KeyCode.W)) * Vector3.forward;
        inputDirection += Convert.ToByte(Input.GetKey(KeyCode.A)) * - Vector3.right;
        inputDirection += Convert.ToByte(Input.GetKey(KeyCode.S)) * - Vector3.forward;
        inputDirection += Convert.ToByte(Input.GetKey(KeyCode.D)) * Vector3.right;
        _processedInput.direction = inputDirection.normalized;
        inputDirection += Convert.ToByte(Input.GetKeyDown(KeyCode.Space)) * Vector3.up;

        var sprint = Input.GetKey(KeyCode.LeftShift);
        _processedInput.isSprinting = sprint;

        _processedInput.cameraBasis = null;
    }
}

[System.Serializable]
public struct MovementInput
{
    public Vector3 direction;
    public bool isSprinting;
    public Transform cameraBasis;
}
