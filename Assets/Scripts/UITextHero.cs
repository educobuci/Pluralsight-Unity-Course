using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UITextHero : MonoBehaviour {

    private PlayerInventory playerInvetory;
    public int playerEnergy;

	// Use this for initialization
	void Awake () {
        playerInvetory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update () {
        playerEnergy = playerInvetory.collectedEnergy;
        GetComponent<Text>().text = playerInvetory.collectedEnergy.ToString();
	}
}
