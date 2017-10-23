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
    CaracteristicasDoJogo cj;
	public Sanidade s;
	public GeradorDeInimigos gi;
	bool destruiu;

    public AudioSource sourceExplosao;
    public AudioClip clipExplosao;


    public Palavras p;

	//public AudioSource som;
   // public AudioClip somInimigo;
    

    public GameObject nave;

	// Use this for initialization

	void Awake() {
		f = GameObject.FindObjectOfType<Foco> ();
		p = GameObject.FindObjectOfType<Palavras> ();
		cj = GameObject.FindObjectOfType<CaracteristicasDoJogo>();
		s = GameObject.FindObjectOfType<Sanidade> ();
		gi = GameObject.FindObjectOfType<GeradorDeInimigos> ();
		//somInimigo = GameObject.Find ("ItemMenuSelecionado");
	}
	void Start () {
		posicao = 0;

        palavraObjeto.text = p.RetornaPalavra(Sanidade.sanidade);
		palavra = palavraObjeto.text;

        nave = GameObject.FindGameObjectWithTag("Player");

        palavraObjeto.text = p.RetornaPalavra(Sanidade.sanidade);
        palavra = palavraObjeto.text;

       

    }


    

    void Update()
    {
		if (!foco && f.possuiFoco || destruiu)
        {
            return;
        }

		if (Input.anyKeyDown && !CaracteristicasDoJogo.morto)
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
				destruiu = true;
                Invoke("liberarFoco", 0.1f);
            }
        }


    }

    void liberarFoco(){
		f.possuiFoco = false;
		foco = false;
		if (CaracteristicasDoJogo.modoRuim) {
			Sanidade.sanidade -= 5 + CaracteristicasDoJogo.wave*5; //5 OU 10
			cj.atualizarPontuacao(palavra.Length * 100);

		} else {
			Sanidade.sanidade += 30;
			cj.atualizarPontuacao(palavra.Length * 10);
		}

		s.sanidadeTexto.text = "sanity" + Sanidade.sanidade;
		GeradorDeInimigos.totalAtual--;
        
        gi.iniciarWave ();
        Destroy(this.gameObject);
        sourceExplosao.PlayOneShot(clipExplosao);
        StartCoroutine("waitFourSecunds");

    }

    IEnumerator waitFourSecunds()
    {
        yield return new WaitForSeconds(2);
        

    }

}






