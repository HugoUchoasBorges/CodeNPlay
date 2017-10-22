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

    public GameObject PauseGamePanel;

    public GameObject nave;

    // Use this for initialization
    void Start () {
		posicao = 0;
		f = GameObject.FindObjectOfType<Foco> ();
        p = GameObject.FindObjectOfType<Palavras>();
        PauseGamePanel = GameObject.FindGameObjectWithTag("PAUSA");
        palavraObjeto.text = p.RetornaPalavra ();
		palavra = palavraObjeto.text;
        cj = GameObject.FindObjectOfType<CaracteristicasDoJogo>();
        //PauseGamePanel.transform.position = new Vector3(0, 500, 0);
        //PauseGamePanel.SetActive(false);

        nave = GameObject.FindGameObjectWithTag("Player");

        Invoke("LateStart",0.01f);
    }


    private void LateStart()
    {
        PauseGamePanel.SetActive(false);
        //PauseGamePanel.transform.Translate(0,10,0);
       
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

    void menuPausa()
    {

        if (PauseGamePanel.active)
            desativaMenuPausa();

        else
            ativaMenuPausa();
    }

    public void ativaMenuPausa()
    {
        PauseGamePanel.SetActive(true);
        invulneravel();

    }

    public void desativaMenuPausa()
    {
        PauseGamePanel.SetActive(false);
        vulneravel();
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

