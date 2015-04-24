using UnityEngine;
using System.Collections;

public class Detonateonhit : MonoBehaviour {

	public GameObject explosionPrefab;
	public float damage = 200f; // Damage at center of explsion
	public float explosionRadius =3f;

	void OnCollisonEnter(){
		Debug.Log ("On CollisonEnter");
		//Detonate ();

		}

	void onTriggerEnter(){
		//Detonate ();
		Debug.Log ("On TriggerEnter");
	}





	/*
	void Detonate (){
		Destroy (gameObject);
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);

		//GameObject.FindObjectOfType (typeof(HasHealth)); // can be slow if many objects


		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (Collider c in colliders) {
			HasHealth h = c.GetComponent <HasHealth>();
			if(h!=null){
				//Radius
				float dist= Vector3.Distance (transform.position, c.transform.position);
				float damageRatio= 1f - dist / explosionRadius;
				h.ReceiveDamage(damage * damageRatio);


			}
		
		}


			}  */

}
