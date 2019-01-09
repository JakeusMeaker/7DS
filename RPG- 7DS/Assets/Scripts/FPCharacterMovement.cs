using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharacterMovement : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    private float translation;
    private float straffe;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        translation = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
