using UnityEngine;
using System.Collections.Generic;

public class Chat : MonoBehaviour 
{

	public List<string> chatHistory = new List<string>();
	private string currentMessage = string.Empty;


	private void SendMessage(){


		if (!string.IsNullOrEmpty (currentMessage.Trim ())) {
			GetComponent<NetworkView> ().RPC ("ChatMessage", RPCMode.AllBuffered, new object[] {currentMessage});
			currentMessage = string.Empty;
			
		}
	
	
	}

	private void Bottom()
	{
	
		currentMessage = GUI.TextField (new Rect (0,Screen.height -20,175,20), currentMessage);
		if (GUI.Button(new Rect (200,Screen.height-20,75,20) , "Send"))
		{
			
			SendMessage();
		}
	

		GUILayout.Space (15);

		for (int i=chatHistory.Count-1; i>=0; i--)
			GUILayout.Label (chatHistory [i]);




	
	}// end Bottom



	private void Top()
	{
	
		GUILayout.Space (20);
		GUILayout.BeginHorizontal (GUILayout.Width (250));
		currentMessage = GUILayout.TextField (currentMessage);
		
		if (GUILayout.Button ("Send")) {
			SendMessage();
		}
		
		GUILayout.EndHorizontal ();
		
		foreach (string c in chatHistory) {
			GUILayout.Label (c);
	
		}


	}// end TOP







	private void OnGUI()
	{

		if (!NetworkMenu.Connected)
			return;
	

		Bottom (); // This function draws GUI chat on bottom




	}// end OnGUI





		//Remote Procedure Call
	[RPC]  
	public void ChatMessage(string Message)
	{

		chatHistory.Add(Message);
	
	}// end RPC-ChatMessage




}//end class Chat


















