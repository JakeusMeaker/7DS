using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public int index;
    public int radius = 2;
    public GameObject prefab;
    new public string name;
    public Sprite icon;
    public Text text;
    public Text heldText;
    public string itemText;
    private bool pickedUp;
    private bool withinRange;
    private GameObject player;


    InventoryManager inventoryManager;

    // Use this for initialization
    void Start () {
        inventoryManager = InventoryManager.instance;
        player = GameObject.FindGameObjectWithTag("Player");
        pickedUp = false;
        itemText = name;
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

    private void OnEnable()
    {
        text = GameObject.FindGameObjectWithTag("UIText").GetComponent<Text>();
        heldText = GameObject.FindGameObjectWithTag("HeldItemUI").GetComponent<Text>();
    }
        
    public void OnMouseUpAsButton() //Selects this item as current selectable
    {

        if (!pickedUp && withinRange)
        {
            inventoryManager.SelectedItem(index); //Call this when clicking an item in your inventory. This sets it as the item to examine.
            gameObject.SetActive(false);
            heldText.text = "Holding " + name;
            heldText.enabled = true;
            text.text = null;
            pickedUp = true;

            //Findsomewhere to call inventoryManager.ResetSelectedItem() otherwise your last item will be permanently selected until overridden;
        }
                               
    }
           
    private void OnMouseOver()
    {
        if (!pickedUp && withinRange)
        {
            text.enabled = true;
            text.text = itemText;
        }
        else
        {
            text.enabled = false;
        }

    }

    private void OnMouseExit()
    {
        if (!pickedUp)
        {
            text.enabled = false;
            text.text = null;
        }
    }
}
