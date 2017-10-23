using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaracteristicasDoJogo : MonoBehaviour {

    public static int totalVidas;
    public int pontuacao = 0;
    public Text pontuacaoText;
	public static bool modoRuim;
    public static bool jogoPausado;
	public static int wave;
	public static bool morto;

    public GameObject game_over_panel;

    // Use this for initialization
    void Start () {
        totalVidas = 3;
        pontuacao = 0;
        pontuacaoText.text = "Score: " + pontuacao;
		modoRuim = true; // true implica inicio com as condições normais de jogo. Inicie com false somente para debugs
        jogoPausado = false;
		wave = 1;
    }

    public void atualizarPontuacao(int novaPontuacao)
    {
        pontuacao += novaPontuacao;
        pontuacaoText.text = "Score: " + pontuacao;
    }

    // Update is called once per frame
    void Update () {
		if (Sanidade.sanidade <= 0) {
			Debug.Log ("VOCE VENCEU");
            //mensagemFinal("Você Venceu!!!");
        } else if (Sanidade.sanidade >= 200) {
            //mensagemFinal("Você Perdeu!!!");
            Debug.Log ("PERDEU");
		}
			
	}

    void mensagemFinal(string mensagem)
    {
        game_over_panel.SetActive(true);
        //GameObject texto = GameObject.FindGameObjectWithTag("FINAL");
        //Text texto = game_over_panel.GetComponentInChildren<Text>();
        //texto.GetComponent<Text>().text = mensagem;
        
    }
		
}
