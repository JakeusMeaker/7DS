using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    public int index;
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject itemPrefab;
    public GameObject itemPrefabExam;
    
    public virtual void Use()
    {
        //use the item
        //something might happen

        Debug.Log("Using " + name); 
    }

   

    
}
