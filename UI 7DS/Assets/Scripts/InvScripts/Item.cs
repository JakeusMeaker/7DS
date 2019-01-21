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
    

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Use()
    {

    }


    private void OnMouseOver()
    {
        text.enabled = true;
        text.text = "[E] " + name;
    }
}
