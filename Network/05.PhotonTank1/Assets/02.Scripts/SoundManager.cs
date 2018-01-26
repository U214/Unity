using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	static SoundManager _instance = null;
	public static SoundManager Instance()
	{
		return _instance;
	}

	void Start () 
	{
		if (_instance == null)
			_instance = this;
	}

	public void PlaySfx(AudioClip clip, Transform tr)
	{
		GetComponent<AudioSource>().PlayOneShot(clip);	
//		AudioSource.PlayClipAtPoint(clip, tr.position);
	}
}
