using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public bool dialogueActive;
	public string[] dialogLines;
	public int currentLine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogueActive && Input.GetKeyDown(KeyCode.Space))
		
		{
			
			
			currentLine++;
		}

		if(currentLine >= dialogLines.Length)
		{
			dBox.SetActive(false);
			dialogueActive = false;
			currentLine = 0;
		}

		//dText = dialogLines[currentLine];
	}

	public void ShowBox(string dialogue)
	{
		dialogueActive = true;
		dBox.SetActive(true);
		dText.text = dialogue;

	}
}
