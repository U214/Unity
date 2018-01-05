﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDynamicChange : MonoBehaviour {

    public Material[] _M_Top1;
    public Material[] _M_Top2;
    public Material[] _M_Pants1;
    public Material[] _M_Pants2;

    public GameObject _Top1;
    public GameObject _Top2;
    public GameObject _Pants1;
    public GameObject _Pants2;

    int nTop1 = 0;
    int nTop2 = 0;
    int nPants1 = 0;
    int nPants2 = 0;

    public void ChangeTop1()
    {
        _Top1.SetActive(true);
        _Top2.SetActive(false);
        nTop1++;

        if (nTop1 > _M_Top1.Length - 1)
        {
            nTop1 = 0;
        }

        CharMaterialSet(_Top1, _M_Top1[nTop1]);
    }

    public void ChangeTop2()
    {
        _Top2.SetActive(true);
        _Top1.SetActive(false);
        nTop2++;

        if (nTop2 > _M_Top2.Length - 1)
        {
            nTop2 = 0;
        }

        CharMaterialSet(_Top2, _M_Top2[nTop2]);
    }

    public void ChangePants1()
    {
        _Pants1.SetActive(true);
        _Pants2.SetActive(false);
        nPants1++;

        if (nPants1 > _M_Pants1.Length - 1)
        {
            nPants1 = 0;
        }

        CharMaterialSet(_Pants1, _M_Pants1[nPants1]);
    }

    public void ChangePants2()
    {
        _Pants2.SetActive(true);
        _Pants1.SetActive(false);
        nPants2++;

        if (nPants2 > _M_Pants2.Length - 1)
        {
            nPants2 = 0;
        }

        CharMaterialSet(_Pants2, _M_Pants2[nPants2]);
    }

    void CharMaterialSet(GameObject obj, Material mat)
    {
        obj.GetComponent<Renderer>().material = mat;
    }
}
