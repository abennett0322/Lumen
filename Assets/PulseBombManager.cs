using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseBombManager : MonoBehaviour {

	public static int pulseBombCount;
	public Player player;

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		pulseBombCount = 3;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "x " + pulseBombCount;
	}
}
