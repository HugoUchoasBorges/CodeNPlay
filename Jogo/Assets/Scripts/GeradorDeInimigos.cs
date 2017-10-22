using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeradorDeInimigos : MonoBehaviour {

    public GameObject[] inimigos;

    public static int totalInimigos = 10;
	public static int totalAtual;
    public GameObject painel;
    public Transform transformPlayer;

    public int waveAtual;

	// Use this for initialization
	void Start () {
		totalInimigos = 8;
		totalAtual = totalInimigos;
        //transicaoWave();
        InstanciarInimigos(totalInimigos);

        waveAtual = 1;

        painel = GameObject.FindGameObjectWithTag("WAVE");

        Invoke("LateStart", 0.1f);
    }

    void LateStart()
    {
        painel.SetActive(false);
    }
	
	void InstanciarInimigos(int totalInimigos)
    {
        for(int i = 0; i < totalInimigos; i++)
        {
            GameObject inimigoInstanciado = (GameObject)Instantiate(inimigos[0]);
            //Instantiate(inimigos[0]);
            inimigos[Random.Range(0, inimigos.Length)].transform.position = new Vector3(Random.Range(Nave.bordaEsquerdaDaTela, Nave.bordaDireitaDaTela), Random.Range(Nave.baseDaTela, Nave.topoDaTela), 0);
        }
    }


	void Update() {
		

	}

	public void iniciarWave(int sanidade) {
		if (sanidade > 100) {
			CaracteristicasDoJogo.estadoJogo = 1;
		} else {
			CaracteristicasDoJogo.estadoJogo = 0;
		}
			

		if (totalAtual == 0) {
            waveAtual++;
            transicaoWave();
			totalInimigos += 3;
			totalAtual = totalInimigos;
		}
	}

    public void transicaoWave()
    {
        
        if(painel != null)
        {
            painel.SetActive(true);

            Text texto = (painel.GetComponentInChildren<Text>());
            texto.text = "WAVE " + waveAtual;
        }
        

        Invoke("painelTransicao", 4);
    }

    public void painelTransicao()
    {

        InstanciarInimigos(totalInimigos);
        painel.SetActive(false);
    }
}
