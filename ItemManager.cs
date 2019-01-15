using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {


    public GameObject[] itemPrefabs;

    public GameObject loadingScreen;
    Clickable[] clickables;

    GameObject[] objects;

     static int selectedObject = 0;

    private void Start()
    {
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        loadingScreen.SetActive(true);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        clickables = new Clickable[itemPrefabs.Length];
        objects = new GameObject[itemPrefabs.Length];

        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            clickables[i] = itemPrefabs[i].GetComponent<Clickable>();
            yield return wait;
            objects[i] = Instantiate(clickables[i].prefab,
                                        GameObject.FindGameObjectWithTag(clickables[i].name).transform.position, Quaternion.identity);
            yield return wait;
            clickables[i].index = i;
            yield return wait;
        }
        yield return null;
        loadingScreen.SetActive(false);
    }

    public static void DoSomething(int index)
    {
        //clickables[index]
        selectedObject = index;

    }

}
