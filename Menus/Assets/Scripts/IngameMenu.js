#pragma strict


 private var isMenuOpen  : boolean = false;

function Update()
{
	
	if(Input.GetKeyDown("escape"))
	{
		if(!isMenuOpen)
		{
			Time.timeScale =0;
			isMenuOpen=true;
			Cursor.lockState = CursorLockMode.None;
			GameObject.Find("MenuBackground").GetComponent(Renderer).enabled=true;
			GameObject.Find("Quit_Game").GetComponent(Renderer).enabled=true;
			GameObject.Find("Resume_Game").GetComponent(Renderer).enabled=true;
			GameObject.Find("Options_Game").GetComponent(Renderer).enabled=true;
		}
		else 
		{
		
				Time.timeScale =1;
				isMenuOpen=false;
				Cursor.lockState = CursorLockMode.Locked; 
				GameObject.Find("MenuBackground").GetComponent(Renderer).enabled=false;
				GameObject.Find("Quit_Game").GetComponent(Renderer).enabled=false;
				GameObject.Find("Resume_Game").GetComponent(Renderer).enabled=false;
				GameObject.Find("Options_Game").GetComponent(Renderer).enabled=false;
		}
	

	}
}


