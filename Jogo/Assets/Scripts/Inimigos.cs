using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigos : MonoBehaviour
{

    public string palavra;
    public int pontuacao;

    bool acertarLetra;

    //Variáveis para gerar e movimentar inimigos aleatoriamente
    public float impulsoMaximo;
	public float impulsoMinimo;
    public float rotacaoMaxima;
    public Rigidbody2D rigidBody2D;

    public float topoDaTela;
    public float baseDaTela;
    public float bordaEsquerdaDaTela;
    public float bordaDireitaDaTela;

	Vector2 impulso;
	float rotacao;


    void Start()
    {
        topoDaTela = 6.2f;
        baseDaTela = -6.2f;
        bordaEsquerdaDaTela = -10.69f;
        bordaDireitaDaTela = 10.69f;
        impulsoMaximo = 200;
		impulsoMinimo = 150;
        rotacaoMaxima = 200;

		if (Random.Range (0, 2) == 0) {
			impulso = new Vector2 (Random.Range (-impulsoMinimo, impulsoMaximo), 200);
			rotacao = Random.Range (-rotacaoMaxima, rotacaoMaxima);
		} else {
			impulso = new Vector2 (200, Random.Range (-impulsoMinimo, impulsoMaximo));
			rotacao = Random.Range (-rotacaoMaxima, rotacaoMaxima);
		}

		rigidBody2D.AddForce(impulso);
		rigidBody2D.AddTorque(rotacao);
		InvokeRepeating ("correcaoPosicao", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPosicao = transform.position;

        if (transform.position.y > topoDaTela)
        {
            novaPosicao.y = baseDaTela;
        }
        if (transform.position.y < baseDaTela)
        {
            novaPosicao.y = topoDaTela;
        }
        if (transform.position.x > bordaDireitaDaTela)
        {
            novaPosicao.x = bordaEsquerdaDaTela;
        }
        if (transform.position.x < bordaEsquerdaDaTela)
        {
            novaPosicao.x = bordaDireitaDaTela;
        }

        transform.position = novaPosicao;

    }

    void OnCollisionEnter2D(Collision2D colisao)
    {

        Vector2 normal = colisao.contacts[0].normal;
        Inimigos inimigo = colisao.transform.GetComponent<Inimigos>();
        
        Nave nave = colisao.transform.GetComponent<Nave>();


        if (inimigo != null)
        {
            //print("Colisão entre inimigos");
            //GetComponent<Collider2D>().isTrigger = true;
            
        }
        if(nave != null)
        {
            //print("Colisão entre Player");
            //GetComponent<Collider2D>().isTrigger = true;
            
            //Game Over
        }
        
        //Destroy(this.gameObject);
        pontuacao += 10;
    }

	void correcaoPosicao() {
		// Usada para evitar que um inimigo fique fora da tela onde sua palavra não pode ser vista
		rigidBody2D.AddForce(new Vector2(Random.Range(-5, 5) + 10, Random.Range(-5, 5) + 10));
	}
}
