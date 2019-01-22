using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharacterMovement : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    private float translation;
    private float straffe;
    private bool isPaused;
    private CameraRotations cameraRotations;

    void Start()
    {
        cameraRotations = GetComponentInChildren<Camera>().GetComponent<CameraRotations>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void Update()
    {
        translation = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown(KeyCode.Escape))
            {
            if (!isPaused)
            {
                isPaused = true;
                cameraRotations.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;

            }

            else if (isPaused)
            {
                isPaused = false;
                cameraRotations.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;

            }
        }


    }
}
