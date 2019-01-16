using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject selectionUI;
    private bool cursorLock;
    public Camera cam;
    bool invntryOpen;

    Inventory inventory;
    
    InventorySlot[] slots;

    

	// Use this for initialization
	public void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
	}
	
	// Update is called once per frame
	public void Update () {
        if (Input.GetButtonDown("Inventory") && !invntryOpen)
        {
            inventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cam.GetComponent<CameraRotations>().enabled = false;
            invntryOpen = true;

        }else if(Input.GetButtonDown("Inventory") && invntryOpen)
        {
            selectionUI.SetActive(false);
            inventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam.GetComponent<CameraRotations>().enabled = true;
            invntryOpen = false;
            
        }
                              
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    
   
}
