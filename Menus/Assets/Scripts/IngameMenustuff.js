var isQuit=false;

function OnMouseEnter()
	{
	//change text color
	GetComponent.<Renderer>().material.color=Color.red;
	}

function OnMouseExit()
{
	//change text color
	GetComponent.<Renderer>().material.color=Color.white;
}

function OnMouseUp()
{
	//is this quit
	if (isQuit==true) {
	//quit the game
	Application.Quit();
	}
	else {
	//resume
				//Cursor.lockState = CursorLockMode.Locked;
				GameObject.Find("MenuBackground").GetComponent(Renderer).enabled=false;
				GameObject.Find("Quit_Game").GetComponent(Renderer).enabled=false;
				GameObject.Find("Resume_Game").GetComponent(Renderer).enabled=false;
				GameObject.Find("Options_Game").GetComponent(Renderer).enabled=false;
	
	}
}

function Update()
{
		//quit game if escape key is pressed
		if (Input.GetKeyDown("p"))
		 { 
		 		//Cursor.lockState = CursorLockMode.Locked;
				GameObject.Find("MenuBackground").GetComponent(Renderer).enabled=false;
				GameObject.Find("Quit_Game").GetComponent(Renderer).enabled=false;
				GameObject.Find("Resume_Game").GetComponent(Renderer).enabled=false;
				GameObject.Find("Options_Game").GetComponent(Renderer).enabled=false;
		 }
}