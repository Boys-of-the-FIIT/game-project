using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerRotation : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    [Inject]
    public void Construct(Camera camera)
    {
        mainCam = camera;
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        var rotation = mousePos - new Vector3(transform.position.x, transform.position.y, 0);
        var rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0,0, rotationZ);
    }
}
