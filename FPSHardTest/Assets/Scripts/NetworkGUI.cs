using UnityEngine;
using System.Collections;

public class NetworkGUI : MonoBehaviour {

	void OnGUI(){
		if (GUI.Button (new Rect (10, 10, 150, 100), "Buttony"))
						print ("Button Clicked");

	}
}
