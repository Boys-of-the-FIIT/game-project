using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerRotation : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;

    [Inject]
    public void Construct(Camera camera)
    {
        mainCamera = camera;
    }

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log($"Mouse Pos: {mousePos}");
    }

    private void FixedUpdate()
    {
        var rotation = mousePos - new Vector3(transform.position.x, transform.position.y, 0);
        var rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0,0, rotationZ);
    }
}
