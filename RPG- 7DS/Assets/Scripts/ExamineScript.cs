using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineScript : MonoBehaviour {

    public float dragSpeed = 100f;
    
    public Vector3 defaultpos;

    private void Start()
    {
        defaultpos = new Vector3(0, 0, 0);
    }

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * dragSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * dragSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX, Space.World);
        transform.Rotate(Vector3.right, rotY, Space.World);
    }

    private void OnMouseUp() //resets the item back to its origional position
    {
        transform.rotation = Quaternion.Euler(defaultpos);  
    }

}
