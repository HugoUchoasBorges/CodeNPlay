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
	public CaracteristicasDoJogo cj;

	// Use this for initialization
	void Start () {
		posicao = 0;
		f = GameObject.FindObjectOfType<Foco> ();
		p = GameObject.FindObjectOfType<Palavras> ();
		palavraObjeto.text = p.RetornaPalavra ();
		palavra = palavraObjeto.text;
        cj = GameObject.FindObjectOfType<CaracteristicasDoJogo>();
    }

    void Update()
    {
        if (!foco && f.possuiFoco)
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            string entrada = Input.inputString.ToUpper();
            if (entrada.Equals(palavra[posicao].ToString()))
            {
                if (posicao == 0 && !f.possuiFoco)
                {
                    f.possuiFoco = true;
                    foco = true;
                }
                
                posicao++;
                palavraObjeto.text = palavra.Substring(posicao);
            }



            if (posicao > 0)
            {
                palavraObjeto.color = Color.red;
            }

            if (posicao == palavra.Length)
            {
                palavraObjeto.text = "destruiu";
                Invoke("liberarFoco", 0.1f);

            }
        }


    }

    void liberarFoco(){
		f.possuiFoco = false;
		foco = false;
        cj.atualizarPontuacao(palavra.Length * 100);
        Destroy (this.gameObject);
	}
		
}

