using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour 
{

	public string connectionIP = "127.0.0.1";
	public int portNum         = 8080;

	public static bool Connected { get; private set;}

	private void OnConnectedToServer()
	
	{
		Connected = true;
		// client has connected

	}

	private void OnServerInitialized(){
		Connected = true;
	// the server is initiaized
	
	}


	private void OnDisconnectedFromServer()
	{
	
		Connected = false;
	
	}






	private void OnGUI()
	{
		// show that little menu
		if(!Connected)
		{

	
					connectionIP = GUILayout.TextField (connectionIP);
					int.TryParse(GUILayout.TextField (portNum.ToString()), out portNum);




					if(GUILayout.Button("Connect"))
						{
						Network.Connect (connectionIP,portNum);
						}

					if(GUILayout.Button("Host"))
						{
						Network.InitializeServer(4,portNum, true);
						}

		}//else show connections
		else 
			GUILayout.Label ("Connections: " + Network.connections.Length.ToString());
		
	}



}
