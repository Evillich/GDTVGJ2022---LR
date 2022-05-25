using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownCamera : CameraRig
{
    [SerializeField] Vector3 positionOffset;
    [SerializeField] float rotationSpeed;


    private void Update()
    {
        if (focusMoved)
            MoveAround();
        if (Input.GetKey(KeyCode.Q))
            RotateAround(true);
        if (Input.GetKey(KeyCode.E))
            RotateAround(false);        
    }

    void MoveAround()
    {
        focusMoved = false;
        transform.position = focusPoint.position + positionOffset;
    }

    void RotateAround(bool rotateLeft)
    {
        transform.RotateAround(focusPoint.position, focusPoint.up, (rotateLeft ? -rotationSpeed : rotationSpeed) * Time.deltaTime);
        positionOffset = transform.position - focusPoint.position;
    }
}
