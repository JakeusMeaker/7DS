using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
   
    public GameObject[] itemPrefabs;
    public Transform previewPoint;
    public GameObject loadingScreen;

    private GameObject[] previewObjects;
    Item[] items;

    GameObject[] objects;

    public static int lastSelectedObject {get; private set;} //makes the variable accessable but cant be changed
    
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Setup());
	}
	
	IEnumerator Setup()
    {
        loadingScreen.SetActive(true);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        items = new Item[itemPrefabs.Length];
        objects = new GameObject[itemPrefabs.Length];
        previewObjects = new GameObject[itemPrefabs.Length];

        for (int i = 0; i < itemPrefabs.Length; i++) // Tight Coupling
        {
            items[i] = itemPrefabs[i].GetComponent<Item>();
            objects[i] = Instantiate(items[i].prefab, 
                                GameObject.FindGameObjectWithTag(items[i].name).transform.position, Quaternion.identity);
            previewObjects[i] = Instantiate(items[i].prefab, previewPoint);
            previewObjects[i].GetComponent<Item>().enabled = false;
            previewObjects[i].AddComponent<ExamineScript>();
            previewObjects[i].SetActive(false);
            items[i].index = i;
            yield return wait;
        }
        yield return null;
        loadingScreen.SetActive(false);
    }

    public static void DoSomething(int index)
    {
        lastSelectedObject = index;
    }
}
