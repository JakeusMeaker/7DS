﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotations : MonoBehaviour
{

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public GameObject character;
    private Vector2 mouseLook;
    private Vector2 smoothV;

    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    void Update()
    {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -60f, 60f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

    }

}
