using UnityEngine;
using System.Collections;

public class MobHealth : MonoBehaviour {

	public int hitPoints = 100;
	int currentHitPoints;



	// Use this for initialization

	void Start () {
		currentHitPoints = hitPoints;
	}
	


	[RPC]
	public void TakeDamage(int amt) {
		currentHitPoints -= amt;
		if (currentHitPoints <= 0) {
			Score.AddPoint();
					Die ();
				}

		else {

				}


			}

	void Die()
	
	
	{
				
		PhotonView pv = GetComponent<PhotonView> ();
		if (pv.instantiationId == 0) {
			Destroy(gameObject);

		}
		else {
			if (pv.isMine){
				PhotonNetwork.Destroy(gameObject);
			}
		}

	}
}
