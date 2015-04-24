/*using UnityEngine;
using System.Collections;

public class FXManager : MonoBehaviour {

	public AudioClip SwordSwing;
	public GameObject SwordSwingPrefab;

	[RPC]
	void fxSwordSwing( Vector3 startPos, Vector3 endpos) {
		//AudioSource.PlayClipAtPoint (SwordSwing, startPos);

		GameObject swordFX = (GameObject) Instantiate(SwordSwingPrefab, startPos, Quaternion.LookRotation(endpos - startPos));
		LineRenderer lr = swordFX.transform.Find ("LineFx").GetComponent<LineRenderer> ();
		lr.SetPosition (0, startPos);
		lr.SetPosition (1, endpos);

		}





}*/

using UnityEngine;
using System.Collections;

public class FXManager : MonoBehaviour {
	
	public GameObject Swordprefab;
	
	[RPC]
	void fxSwordSwing( Vector3 startPos, Vector3 endPos ) {
			
		if(Swordprefab != null) {
			GameObject swordFX = (GameObject)Instantiate(Swordprefab, startPos, Quaternion.LookRotation( endPos - startPos ) );
			
			LineRenderer lr = swordFX.transform.Find ("LineFx").GetComponent<LineRenderer> ();
		
			if(lr != null) {
				lr.SetPosition(0, startPos);
				lr.SetPosition(1, endPos);
			}
			else {
				Debug.LogError("swordFXPrefab's linerenderer is missing.");
			}
		}
		else {
			Debug.LogError("swordtFXPrefab is missing!");
		}
		
	}
	
}
