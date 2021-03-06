﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{
    public Vector2 mouseLook;
    public Vector2 smoothV;
    public float sensitivity;
    public float smoothing;

    public GameObject character;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        character = transform.parent.gameObject;
    }

    void Update()
    {
        Vector2 vct2 = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        smoothV.x = Mathf.Lerp(smoothV.x, vct2.x, 1 / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, vct2.y, 1 / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
