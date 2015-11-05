using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMotherShip : MonoBehaviour {

    private MotherShip motherShip;
    public int collected;
    public int needed;

	// Use this for initialization
	void Awake () {
        motherShip = GameObject.Find("MotherShip").GetComponent<MotherShip>();
	}
	
	// Update is called once per frame
	void Update () {
        collected = motherShip.collectedEnergy;
        needed = motherShip.neededEnergy;

        GetComponent<Text>().text = string.Format("{0} / {1}", collected, needed);
	}
}
