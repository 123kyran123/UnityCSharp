using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Event {

	//Variables
	private string name;
	private string description;
	private int person_id;

	//Properties
	public string getName(){
		return name;
	}

	//Constructor
	public Event(Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>> Cards, string currentEventCard){

		//loop through all cards
		foreach(var subInfo in Cards[currentEventCard].Keys){
			//All card main information
			//UnityEngine.Debug.Log (Cards[currentEventCard][subInfo]["Main_Info"]["Name"]);

			name = Cards[currentEventCard][subInfo]["Main_Info"]["Name"];

		}

	}

}
