using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    public GameObject[] itemPrefabs;
    public GameObject loadingScreen;
    public int space = 10;
    public List<Item> items = new List<Item>();

    Item[] gameItems;
    GameObject[] objects;

    static int selectedObjects = 0;

    private void Start()
    {
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        loadingScreen.SetActive(true);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        gameItems = new Item[itemPrefabs.Length];
        objects = new GameObject[itemPrefabs.Length];

        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            gameItems[i] = itemPrefabs[i].GetComponent<Item>();
            yield return wait;
            objects[i] = Instantiate(gameItems[i].itemPrefab,
                                             GameObject.FindGameObjectWithTag(gameItems[i].name).transform.position, Quaternion.identity);
            yield return wait;
            gameItems[i].index = i;
            yield return wait;
        }
        yield return null;
        loadingScreen.SetActive(false);
    }

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);

        if(onItemChangedCallback != null)
        onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}