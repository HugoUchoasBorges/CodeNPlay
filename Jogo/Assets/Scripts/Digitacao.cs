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

	public Palavras p;

	public AudioSource som;
	public AudioClip somInimigo;
	public GameObject PauseGamePanel;
    public GameObject HowToPanel;

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
        PauseGamePanel = GameObject.FindGameObjectWithTag("PAUSA");
        HowToPanel = GameObject.FindGameObjectWithTag("HowTo");
        palavraObjeto.text = p.RetornaPalavra(s.sanidade);
		palavra = palavraObjeto.text;

        nave = GameObject.FindGameObjectWithTag("Player");

        palavraObjeto.text = p.RetornaPalavra(s.sanidade);
        palavra = palavraObjeto.text;

        Invoke("LateStart", 0.01f);

    }


    private void LateStart()
    {
        if(PauseGamePanel != null)
            PauseGamePanel.SetActive(false);
    }

    void Update()
    {
		if (!foco && f.possuiFoco || destruiu)
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            string entrada = Input.inputString.ToUpper();
            
            if (Input.GetKeyDown("escape"))
            {
                Debug.Log("ESC APERTADO");
                menuPausa();
            }
            else if (entrada.Equals(palavra[posicao].ToString()))
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
        cj.atualizarPontuacao(palavra.Length * 100);
		if (s.sanidade < 100) {
			s.sanidade += 15;

		} else {
			s.sanidade += 15;
		}

		s.sanidadeTexto.text = "sanity" + s.sanidade;
		GeradorDeInimigos.totalAtual--;
		gi.iniciarWave (s.sanidade);
		som.PlayOneShot (somInimigo);
        Destroy (this.gameObject);
	}

    public void menuPausa(){
        if (PauseGamePanel.active) 
            desativaMenuPausa();

        else
            ativaMenuPausa();
    }

    public void ativaMenuPausa()
    {
        PauseGamePanel.SetActive(true);
        invulneravel();
        CaracteristicasDoJogo.jogoPausado = true;
    }

    public void desativaMenuPausa()
    {
        PauseGamePanel.SetActive(false);
        HowToPanel.SetActive(false);
        vulneravel();
        CaracteristicasDoJogo.jogoPausado = false;
    }


    public void vulneravel()
    {
        nave.GetComponent<Collider2D>().enabled = true;
        nave.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void invulneravel()
    {
        nave.GetComponent<Collider2D>().enabled = false;
        nave.GetComponent<SpriteRenderer>().color = Color.red;
    }


}

