﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Creation : MonoBehaviour {

	public Selector lumberjackSelector;
	public LumberUI lumberUI;

	public GameObject lumberjackBase;

	public InputField username;
	public InputField password;
	public InputField passwordRepeat;
	public Button createButton;
	public Button cancelButton;
	public Text error;

	public Vector3 spawnPoint;

	//TODO: add colour custimization

	public void Cancel()
	{
		lumberUI.displayLogin ();
	}

	public void CreateLumberjack()
	{
		if (lumberjackSelector.findLumberjack (username.text)) 
		{
			error.text = "Name is already taken";
			return;
		}

		if (password.text != passwordRepeat.text) 
		{
			error.text = "Passwords don't match";
			return;
		}

		GameObject lumberjack = Instantiate (lumberjackBase);
		Character lumberjackCharacter = lumberjack.GetComponent<Character> ();
		//call the loadCharacter method in lumberjackCharacter
		lumberjack.transform.position = spawnPoint;

		lumberjackSelector.addLumberjack (lumberjack);
		lumberjackSelector.makeActiveLumberjack (lumberjack);
		lumberUI.displayPlay ();

	}

	// Use this for initialization
	void Start () 
	{
		//Sets up the buttons
		Button[] buttons = this.GetComponentsInChildren<Button> ();
		foreach (Button but in buttons) 
		{
			string name = but.gameObject.name;
			switch (name)
			{
			case "CreateButton":
				createButton = but;
				break;
			case "CancelButton":
				cancelButton = but;
				break;
			default:
				break;
			}
		}

		InputField[] fields = this.GetComponentsInChildren<InputField> ();
		foreach (InputField field in fields) 
		{
			string name = field.gameObject.name;
			switch (name) 
			{
			case "Username":
				username = field;
				break;
			case "Password":
				password = field;
				break;
			case "PasswordRepeat":
				passwordRepeat = field;
				break;
			default:
				break;
			}
		}

		Text[] texts = this.GetComponentsInChildren<Text> ();
		foreach (Text text in texts) 
		{
			string name = text.gameObject.name;
			switch (name) 
			{
			case "Error":
				error = text;
				break;
			default:
				break;
			}
		}

		lumberUI = this.GetComponentInParent<LumberUI> ();
		lumberjackSelector = this.GetComponentInParent<LumberUI> ().lumberjackSelector.GetComponent<Selector>();
	}

	// Update is called once per frame
	void Update () {

	}
}
