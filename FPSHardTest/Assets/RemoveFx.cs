using UnityEngine;
using System.Collections;

public class RemoveFx : MonoBehaviour {
	public float removeFx=1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		removeFx -= Time.deltaTime;

		if (removeFx <= 0) {


			PhotonView pv = GetComponent<PhotonView>();

			if(pv !=null && pv.instantiationId!=0){
				PhotonNetwork.Destroy(gameObject);

			}
			else{
				Destroy(gameObject);
				}




		}
	
	}
}
