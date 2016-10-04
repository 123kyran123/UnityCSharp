using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class readAllCards {
	//Variables
	private Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>> Cards;
	private Dictionary<int, Dictionary<string, Dictionary<string, string>>> Card;
	private Dictionary<string, Dictionary<string, string>> subInfo;
	private Dictionary<string, string> Information;


	// Use this for initialization
	public readAllCards () {
		
	}

	//Read all cards
	public Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>> getData(){
		//Create the List
		Cards = new Dictionary<string, Dictionary<int, Dictionary<string, Dictionary<string, string>>>>();

		//Get all subfolders
		foreach (string folder in System.IO.Directory.GetDirectories(Application.dataPath + "/Cards/")) {
			//All folders within the main Card folder
			//UnityEngine.Debug.Log (folder);

			//Loop through the folders
			foreach (string file in System.IO.Directory.GetFiles(folder + "/")) {

				//Filter out meta files
				if(!file.Contains("meta")){ 

					//All files wtihin the folder
					//UnityEngine.Debug.Log (file);

					//Create card list
					Card = new Dictionary<int, Dictionary<string, Dictionary<string, string>>> ();

					//Create subinfo list
					subInfo = new Dictionary<string, Dictionary<string, string>>();

					//Get all Main info of the cards
					subInfo.Add("Main_Info", getMainInfo(File.ReadAllLines(file), file));
					Card.Add(int.Parse(Regex.Replace(file, "[^0-9]", "")), subInfo);

					string[] splitName = folder.Split ('/');
					Cards.Add(splitName[splitName.Length - 1] + "_" + Regex.Replace(file, "[^0-9]", ""), Card);
				}
			}
		}

		return Cards;
	}

	//Get all the main information
	private Dictionary<string, string> getMainInfo(string[] info, string fileName){
		//Create information list
		Information = new Dictionary<string, string>();
		Information.Add("Name", info[0].Split('=')[1]);

		//Check if person or event card
		if (fileName.Contains ("Event")) {
			//Fill array with terms
			Information.Add("Description", info[1].Split('=')[1]);
			Information.Add("Person", info[2].Split('=')[1]);
			//Call loop subject function to go through all the awnsers
			loopSubject(info, fileName);
		} else {
			//Fill array with terms
			Information.Add("Img", info[1].Split('=')[1]);
			Information.Add("Opinion", info[2].Split('=')[1]);
		}

		return Information;
	}

	//Loop through subject
	private void loopSubject(string[] lines, string fileName){

		//Loop through the subjects
		for (int i = 4; i > lines.Length; i++) {

			//Check if new awnser
			if(lines[i].Contains("={")){

				//Create information list
				Information = new Dictionary<string, string> ();

			} else if(lines[i].Contains("}")){

				//Add the information to the subinfo
				subInfo.Add(lines[i].Split('=')[0], Information);

			}

			Information.Add(lines[i].Split('=')[0], lines[i].Split('=')[1]);
		}
	}
}
