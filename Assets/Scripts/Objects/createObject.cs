using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class createObject {

	//Variables
	private Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>> allCards;
	private Person personClass;
	private Event eventClass;

	private GameObject card_go;
	private GameObject eventCards_go;
	private GameObject peopleCards_go;

	private Text txt;

	//Constructor
	public createObject(){

	}

	//Create all cards from the dictionary
	public void createCardObjects(Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>> Cards){
		//Save all cards
		allCards = Cards;

		//Create parent objects
		eventCards_go = new GameObject();
		eventCards_go.name = "EventCards";
		peopleCards_go = new GameObject();
		peopleCards_go.name = "PersonCards";

		//loop through all cards
		foreach(var card in Cards.Keys){
			//Card info
			//UnityEngine.Debug.Log (Cards[card]);

			//Check what kind of card it is
			if(card.Contains("Event")){ createEventObject(card); }
			if(card.Contains("People")){ createPersonObject(card); }
		}
	}

	//Create event object
	private void createEventObject(string card){
		//create Class & object
		eventClass = new Event(allCards, card);
		createClassObject(card);
		card_go.transform.SetParent(eventCards_go.transform);
		txt.text = eventClass.getName();
	}

	//create person object
	private void createPersonObject(string card){
		//create Class & object
		personClass = new Person(allCards, card);
		createClassObject(card);
		card_go.transform.SetParent(peopleCards_go.transform);
		txt.text = personClass.getName();
	}

	//create the object
	private void createClassObject(string card){
		card_go = new GameObject ();
		card_go.name = card;
		txt = card_go.AddComponent<Text> ();
	}
}
