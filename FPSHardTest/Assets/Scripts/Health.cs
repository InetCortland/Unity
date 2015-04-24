using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	 static public int currentHp = 100;
	public int hitPoints = 100;
	int currentHitPoints;
	GameObject myGameObject;
	GameObject network;
	NetworkManager Name = new NetworkManager ();


	void Update() {

			
	}


	// Use this for initialization

	void Start () {
		this.myGameObject = gameObject;
		currentHitPoints = hitPoints;
		currentHp = hitPoints;
	}
	


	[RPC]
	public void TakeDamage(int amt) {
				currentHitPoints -= amt;
				if (myGameObject.CompareTag ("SelfPlayer")) {
						currentHp = currentHitPoints;

				}

				if (currentHitPoints <= 0) {
							Die ();

						if (myGameObject.CompareTag ("Enemy")) {
								Score.AddPoint ();
						}

						if (this.gameObject.CompareTag("SelfPlayer")) {

							//Name.SpawnMyPlayer();
				
						}
					
		
				}
		}
					

			//NetworkObject.


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
