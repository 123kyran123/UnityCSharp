using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	//Variables
	private Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>> Cards;
	private readAllCards rac;
	private createObject co;

	// Use this for initialization
	void Start () {
		
		//Get all cards in list
		rac = new readAllCards ();
		Cards = rac.getData ();

		//Create all objects
		co = new createObject();
		co.createCardObjects(Cards);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}