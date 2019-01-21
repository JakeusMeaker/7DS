using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public GameObject[] itemPrefabs;
    public Transform previewPoint;
    public GameObject loadingScreen;
    public GameObject inventoryUI;
    public GameObject selectionUI;
    public CameraRotations cam;
    public Text text;

    private GameObject[] previewObjects;
    private bool invntryOpen;
    
    Item[] items;

    GameObject[] objects;

    public static int lastSelectedObject { get; private set; } //makes the variable accessable but cant be changed

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Setup());
        cam = GetComponent<CameraRotations>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory") && !invntryOpen)
        {
            inventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cam.enabled = false;
            invntryOpen = true;

        }
        else if (Input.GetButtonDown("Inventory") && invntryOpen)
        {
            selectionUI.SetActive(false);
            inventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam. enabled = true;
            invntryOpen = false;

        }
    }

    IEnumerator Setup()
    {
        loadingScreen.SetActive(true);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        items = new Item[itemPrefabs.Length];
        objects = new GameObject[itemPrefabs.Length];
        previewObjects = new GameObject[itemPrefabs.Length];
        invntryOpen = false;

        for (int i = 0; i < itemPrefabs.Length; i++) // Tight Coupling
        {
            items[i] = itemPrefabs[i].GetComponent<Item>();
            objects[i] = Instantiate(items[i].prefab,
                                GameObject.FindGameObjectWithTag(items[i].name).transform.position, Quaternion.identity);
            objects[i].AddComponent<Text>();
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

    public static void Examine(int index)
    {
        lastSelectedObject = index;
        //lastSelectedObject;

    }

}
