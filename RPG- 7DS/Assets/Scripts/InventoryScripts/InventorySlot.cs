using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public GameObject examineItem;
    public Transform examinationPoint;
    public ItemPickup pickup;
    public Image icon;


    private Inventory inv;
    Item item;

    private void Start()
    {
        inv = Inventory.instance;
        
    }

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        

    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void ExamineItem()
    {
        if (item != null)
        {
            Debug.Log("Examining " + name);
            //examineItem = inv.
            //examineItem.SetActive(true);
            
        }
    }
}
