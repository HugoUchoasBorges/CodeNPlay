using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaracteristicasDoJogo : MonoBehaviour {

    public static int totalVidas;
    public int pontuacao = 0;
    public Text pontuacaoText;

    private void Awake()
    {
        pontuacao = 0;
    }

    // Use this for initialization
    void Start () {
        totalVidas = 3;
        pontuacao = 0;
        pontuacaoText.text = "Score: " + pontuacao;

    }

    public void atualizarPontuacao(int novaPontuacao)
    {
        pontuacao += novaPontuacao;
        pontuacaoText.text = "Score: " + pontuacao;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
