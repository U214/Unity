using UnityEngine;
using System.Collections;

public class CannonControl : MonoBehaviour {

	public GameObject expEffect;
	public GameObject fireEffect;
	
	public AudioClip expSfx;
	
	public float damage = 30.0f;
	
	void Start () {
		GetComponent<Rigidbody>().AddForce ( transform.forward * 3000.0f);

		Instantiate( fireEffect, transform.position, Quaternion.identity);
		SoundManager.Instance().PlaySfx(expSfx, this.transform);
	}

	void OnTriggerEnter ( Collider Coll ){
		Instantiate ( expEffect, transform.position, Quaternion.identity);
		SoundManager.Instance().PlaySfx(expSfx, this.transform);

		Destroy ( this.gameObject );
	}

}
