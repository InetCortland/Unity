using UnityEngine;
using System.Collections;

public class PreformsAttackProjectile : MonoBehaviour {

	public float cooldown = 1.0f; /// Weapon attack speed
	float cooldownremaining = 0;
	public GameObject projectilePrefab;


	//Getmousebuttondown = Semi auto    Getmousebutton = Full auto 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldownremaining -= Time.deltaTime;

		if (Input.GetMouseButton (0) && cooldownremaining <=0) {

			cooldownremaining = cooldown;


			Instantiate(projectilePrefab, Camera.main.transform.position, Camera.main.transform.rotation);





			}

	}}


	  
