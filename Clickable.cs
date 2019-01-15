using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

    public int index;
    public GameObject prefab;
    public string name;

    private void OnMouseUp()
    {
        ItemManager.DoSomething(index);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
