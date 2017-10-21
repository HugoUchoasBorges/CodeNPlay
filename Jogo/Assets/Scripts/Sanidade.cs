using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanidade : MonoBehaviour
{

    public Text sanidadeTexto;
    public int sanidade;
    // Use this for initialization

    string[] insanidades = {
        "  s aNIDa de:",
        "    sa     NIDa de:",
        "sanIDADEEEEE:",
        "    SAN I   DADE:",
        "s  a a nniD ade"
    };

    void Start()
    {
        sanidade = 100;
        sanidadeTexto.text = "   sanidade: " + sanidade;
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
        sanidadeTexto.text = "   sanidade: " + sanidade;
    }

    void sanidadeTempo2()
    {
        int n = Random.Range(0, 5);
        sanidade -= n;

        sanidadeTexto.text = insanidades[n] + sanidade;
    }
}