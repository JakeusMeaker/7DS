using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    #region Singleton

    public static InventoryManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
            instance = this;
    }

    #endregion

    public GameObject[] itemPrefabs;
    public Transform previewPoint;
    public GameObject loadingScreen;
    public GameObject inventoryUI;
    public GameObject selectionUI;
    public GameObject objectTextUI;
    public Camera cam;
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
        lastSelectedObject = -1;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory") && !invntryOpen)
        {
            inventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cam.GetComponent<CameraRotations>().enabled = false;
            invntryOpen = true;

        }
        else if (Input.GetButtonDown("Inventory") && invntryOpen)
        {
            selectionUI.SetActive(false);
            inventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam.GetComponent<CameraRotations>().enabled = true;
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

    public void Examine() //Examines currently selected item. Called from UI button. Reliant on SelectedItem() being called from Item, otherwise returns null
    {
        if (lastSelectedObject == -1)
            return;

        previewObjects[lastSelectedObject].gameObject.SetActive(true); //TURNS IT ON. You might want to turn it off somehow. I suggest SetActive(false);

    }

    public void SelectedItem(int index) //Sets item for examination. Called from Item script.
    {
        lastSelectedObject = index;
        Debug.Log(lastSelectedObject);
    }

    public void ResetSelectedItem() //UNselects item for examination
    {
        lastSelectedObject = -1;
    }

}
