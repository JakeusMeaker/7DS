using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharacterMovement : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    private float translation;
    private float straffe;
    private bool isPaused;
    private CameraRotations cam;

    void Start()
    {
        cam = GetComponent<CameraRotations>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void Update()
    {
        translation = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape") && !isPaused)
        {
            cam.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown("escape") && isPaused)
        {
            cam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }

    }
}
