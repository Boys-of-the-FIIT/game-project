using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerRotation : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _mousePos;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        var rotation = _mousePos - new Vector3(transform.position.x, transform.position.y, 0);
        var rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0,0, rotationZ);
    }
}
