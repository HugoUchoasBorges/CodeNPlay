using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanidade : MonoBehaviour
{

    public Text sanidadeTexto;
    public static int sanidade;
    // Use this for initialization

    string[] insanidades = {
        "insanity:",
        "    sa     NITy:",
        "in.san:",
        "I    SAN I   TYY:",
        "s  a a nniT yyy:"
    };

    void Start()
    {
        sanidade = 150;
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
        if (CaracteristicasDoJogo.jogoPausado)
            return;
        
		if (CaracteristicasDoJogo.modoRuim) {
			sanidade++;
		} else {
			sanidade--;
		}

		sanidadeTexto.text = "in.sanity: " + sanidade;

    }

    void sanidadeTempo2()
    {
		if (CaracteristicasDoJogo.jogoPausado || !CaracteristicasDoJogo.modoRuim)
            return;
		
		int n = Random.Range(0, 5);
		if (sanidade > 50) {
			sanidade += n;
		} 
        
        sanidadeTexto.text = insanidades[n] + sanidade;
    }
}
