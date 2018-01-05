using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRotateAnim : MonoBehaviour {

    public Material mat1;
    public Material mat2;
    Animator anim;

    void FrontImage()
    {
        GetComponent<Renderer>().material = mat1;
    }

    void BackImage()
    {
        GetComponent<Renderer>().material = mat2;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseUp()
    {
        StartCoroutine("coAnim");
    }

    IEnumerator coAnim()
    {
        anim.SetInteger("aniStep", 1);
        yield return new WaitForSeconds(1.0f);
        anim.SetInteger("aniStep", 0);
    }
}
