using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Text pickupPrompt;
  
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnMouseOver()
    {
        pickupPrompt.enabled = true;
    }

    private void OnMouseExit()
    {
        pickupPrompt.enabled = false;
    }
        
}
