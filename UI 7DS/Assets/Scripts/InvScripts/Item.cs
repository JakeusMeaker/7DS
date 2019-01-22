using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public int index;
    public GameObject prefab;
    new public string name;
    public Sprite icon;
    public Text text;

    public string itemText;

    InventoryManager inventoryManager;

    // Use this for initialization
    void Start () {
        inventoryManager = InventoryManager.instance;
	}

    private void OnEnable()
    {
        text = GameObject.FindGameObjectWithTag("UIText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnMouseUpAsButton() //Selects this item as current selectable
    {
        inventoryManager.SelectedItem(index); //Call this when clicking an item in your inventory. This sets it as the item to examine.
        //Findsomewhere to call inventoryManager.ResetSelectedItem() otherwise your last item will be permanently selected until overridden;
    }


    private void OnMouseOver()
    {
        text.enabled = true;
        text.text = itemText;
    }

    private void OnMouseExit()
    {
        text.enabled = false;
        text.text = null;
    }
}
