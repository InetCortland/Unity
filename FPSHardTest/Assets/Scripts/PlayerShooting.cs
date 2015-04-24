using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float fireRate = 0.5f;
	float cooldown = 0;
	public float range = 2;
	public int damage = 25;

public	FXManager fxManager;

void Start () {

		fxManager = GameObject.FindObjectOfType<FXManager> ();

		if (fxManager == null) {
			Debug.Log("No FX");
		}

}


	// Update is called once per frame
void Update () {
		cooldown -= Time.deltaTime;
		
		if (Input.GetButton ("Fire1")) {
						// Player wants to shoot...so. Shoot.
						Fire ();
				}

	


	}

void Fire() {
				if (cooldown > 0) {
						return;
				}
				//anim.SetBool("Attack", true);
	

				Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
				Transform hitTransform;
				Vector3 hitPoint;

				hitTransform = FindClosestHitObject (ray, out hitPoint);

				if (hitTransform != null) {


						// We could do a special effect at the hit location
						// DoRicochetEffectAt( hitPoint );

						Health h = hitTransform.GetComponent<Health> ();

						while (h == null && hitTransform.parent) {
								hitTransform = hitTransform.parent;
								h = hitTransform.GetComponent<Health> ();
			
						}

						// Once we reach here, hitTransform may not be the hitTransform we started with!
						// This is also where range takes effect.
						// if(Physics.Raycast(ray,range) affects when the damage will be done if h!= null and the person is close




						if (Physics.Raycast (ray, range)) {

								if (h != null) {
										Debug.Log ("We hit: " + hitTransform.name + " For " + damage + " damage.");

										// The next line is == to calling   h.TakeDamage(damage);  but it uses the network
										// RPC(function, photontargets, what we're passing through function)
										h.GetComponent<PhotonView> ().RPC ("TakeDamage", PhotonTargets.AllBuffered, damage);
								}
			
						



						if (fxManager != null) {
								//fxManager.GetComponent<PhotonView> ().RPC ("fxSwordSwing", PhotonTargets.All, Camera.main.transform.position, hitPoint);
						}
		
				} else {
						// We didn't hit anything (except empty space), but let's do a visual FX anyway
												
						if (fxManager != null) {
								hitPoint = Camera.main.transform.position + (Camera.main.transform.forward * 100f);
								//Debug.Log ("It should be working");
								//fxManager.GetComponent<PhotonView> ().RPC ("fxSwordSwing", PhotonTargets.All, Camera.main.transform.position, hitPoint);
						}
		
			
				}
		}

		cooldown = fireRate;
	}

	Transform FindClosestHitObject(Ray ray, out Vector3 hitPoint) {

		RaycastHit[] hits = Physics.RaycastAll(ray);

		Transform closestHit = null;
		float distance = 0;
		hitPoint = Vector3.zero;

		foreach(RaycastHit hit in hits) {
			if(hit.transform != this.transform && ( closestHit==null || hit.distance < distance ) ) {
				// We have hit something that is:
				// a) not us
				// b) the first thing we hit (that is not us)
				// c) or, if not b, is at least closer than the previous closest thing

				closestHit = hit.transform;
				distance = hit.distance;
				hitPoint = hit.point;
			}
		}

		// closestHit is now either still null (i.e. we hit nothing) OR it contains the closest thing that is a valid thing to hit

		return closestHit;

	}
}

	

