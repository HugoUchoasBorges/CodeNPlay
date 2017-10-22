﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanidade : MonoBehaviour
{

    public Text sanidadeTexto;
    public int sanidade;
    // Use this for initialization

    string[] insanidades = {
        "  s aNITY :",
        "    sa     NITy:",
        "sanITYYYYYY:",
        "    SAN I   TYY:",
        "s  a a nniT yyy:"
    };

    void Start()
    {
        sanidade = 100;
        sanidadeTexto.text = "   sanity: " + sanidade;
        InvokeRepeating("sanidadeTempo1", 2f, 3f);
        InvokeRepeating("sanidadeTempo2", 6f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void sanidadeTempo1()
    {
        sanidade--;
        sanidadeTexto.text = "   sanity: " + sanidade;
    }

    void sanidadeTempo2()
    {
        int n = Random.Range(0, 5);
        sanidade -= n;

        sanidadeTexto.text = insanidades[n] + sanidade;
    }
}