using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Digitacao : MonoBehaviour {

	public Text palavraObjeto;
	public string palavra;
	public int posicao;
	public bool foco;
	public Foco f;

	public Palavras p;

	// Use this for initialization
	void Start () {
		posicao = 0;
		palavra = palavraObjeto.text;
		f = GameObject.FindObjectOfType<Foco> ();
		p = GameObject.FindObjectOfType<Palavras> ();
	}

	// Update is called once per frame
	void Update () {
		if (!foco && f.possuiFoco) {
			return;
		}

		foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode))) {
			if (Input.GetKeyDown (kcode) && kcode.ToString ().Equals(palavra[posicao].ToString ())) {
				if (posicao == 0 && !f.possuiFoco && !foco) {
					f.possuiFoco = true;
					foco = true;
				}

				Debug.Log ("KeyCode down: " + kcode);
				posicao++;
				palavraObjeto.text = palavra.Substring (posicao);
			}
				
		}

		if (posicao > 0) {
			palavraObjeto.color = Color.red;
		}

		if (posicao == palavra.Length) {
			palavraObjeto.text = "destruiu";
			Invoke ("liberarFoco", 1f);

			//libera a palavra assim que um inimigo é destruido
			p.liberaPalavra(palavra[palavra.Length]); 
		}
			
	}

	void liberarFoco(){
		f.possuiFoco = false;
		foco = false;
	}
		
}

