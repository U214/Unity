using UnityEngine;
using System.Collections;

public class csSceneTrans3 : MonoBehaviour {

	GUITexture Black_screen;
	public float Fade_Time = 2f;
	private float Fade_Max = 0.5f;
	private float _time;
	private bool FadeIn_ing = true;
	private bool FadeOut_ing;

	void Start ()
	{
		Black_screen = GetComponent<GUITexture> ();
	}

	void Update ()
	{
		if (FadeIn_ing) {
			_time += Time.deltaTime;
			Black_screen.color = Color.Lerp (new Color (0, 0, 0, Fade_Max), new Color (0, 0, 0, 0), _time / Fade_Time);
		}

		if (FadeOut_ing) {
			_time += Time.deltaTime;
			Black_screen.color = Color.Lerp (new Color (0, 0, 0, 0), new Color (0, 0, 0, Fade_Max), _time / Fade_Time);
		}

		if (_time >= Fade_Time) {
			_time = 0;
			FadeIn_ing = false;
			FadeOut_ing = false;
		}
	}

	public void SceneTrans3_1 () {
		FadeOut_ing = true;
		StartCoroutine (TransScene ("05-Scene3-1", Fade_Time));
	}

	public void SceneTrans3_2 () {
		FadeOut_ing = true;
		StartCoroutine (TransScene ("06-Scene3-2", Fade_Time));
	}

	private IEnumerator TransScene (string scene, float interval)
	{
		yield return new WaitForSeconds(interval); 
		Application.LoadLevel (scene);
		//SceneManager.LoadScene (scene);
	}
}

