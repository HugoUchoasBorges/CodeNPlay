using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour {

	public string palavra;
	public int pontuacao;

	bool acertarLetra;

	// Use this for initialization
	void Start (string palavra) {
		this.palavra = palavra;
	}
	
	// Update is called once per frame
	void Update () {


	}

	bool acertouLetra(char letra){
		int posicaoLetra;
	}

	void OnCollisionEnter2D(Collision2D collision){
		Destroy (this.gameObject);
		pontuacao += 10;
	}
		
}
