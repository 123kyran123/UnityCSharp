using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person {
	
	//Variables
	private string name;

	//Properties
	public string getName(){
		return name;
	}

	public Person(Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>> Cards, string currentPersonCard){

		//loop through all cards
		foreach(var subInfo in Cards[currentPersonCard].Keys){
			//All card main information
			//UnityEngine.Debug.Log (Cards[currentEventCard][subInfo]["Main_Info"]["Name"]);

			name = Cards[currentPersonCard][subInfo]["Main_Info"]["Name"];

		}
	}

}
