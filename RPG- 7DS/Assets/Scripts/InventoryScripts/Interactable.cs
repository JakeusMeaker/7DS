using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Text pickupPrompt;
    public GameObject player;
    public bool withinRange;

    private void Start()
    {
        FindPlayer();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= radius)
        {
            withinRange = true;
        }
        else
        {
            withinRange = false;
        }
    }

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Interact()
    {

        Debug.Log("Interacting with " + transform.name);
        pickupPrompt.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnMouseOver()
    {
        if (withinRange)
        {
            pickupPrompt.enabled = true;

            if (Input.GetButtonDown("Pickup"))
            {
                Interact();
            }
        }
            

    }

    private void OnMouseExit()
    {
        pickupPrompt.enabled = false;
    }


        
}
