using UnityEngine;
using System.Collections;

public class PreformsAttack : MonoBehaviour {

	public float cooldown = 1.0f; /// Weapon attack speed
	float cooldownremaining = 0;
	public float range = 100f;
	public GameObject debrisPrefab; // hit effect
	public float damage= 25.0f; // Damage


	//Getmousebuttondown = Semi auto    Getmousebutton = Full auto 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldownremaining -= Time.deltaTime;

		if (Input.GetMouseButton (0) && cooldownremaining <=0) {

			cooldownremaining = cooldown;

			Camera.main.ScreenPointToRay(Input.mousePosition );

			Ray ray = new Ray ( Camera.main.transform.position + Camera.main.transform.forward*0.4f , Camera.main.transform.forward);
			RaycastHit hitInfo;

			if( Physics.Raycast (ray, out hitInfo, range)){
				Vector3 hitPoint=hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				Debug.Log ("Hit Object: " + go.name);
				Debug.Log ("Hit Point; " + hitPoint);



				// Doing damage
				/*
				HasHealth h = go.GetComponent <HasHealth>();
				if(h != null){

					h.ReceiveDamage(damage);
				}
*/

				if(debrisPrefab != null) {
					Instantiate ( debrisPrefab, hitPoint, Quaternion.identity);
				}

			}


			}

	}}


	  
