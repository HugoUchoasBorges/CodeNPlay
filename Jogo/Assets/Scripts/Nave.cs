using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    public Rigidbody2D rigidBody2D;

    public float impulso;
    public float impulsoDeRotacao;
    private float _entradaParaImpulso;
    private float _entradaParaRotacao;

    public float topoDaTela;
    public float baseDaTela;
    public float bordaEsquerdaDaTela;
    public float bordaDireitaDaTela;


	public int quantidadeDeVidas = 3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _entradaParaImpulso = Input.GetAxis("Vertical");
        _entradaParaRotacao = Input.GetAxis("Horizontal");

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

        //GetComponent<Transform>().position += Vector3.right * movimentoHorizontal * velocidadeDeMovimento * Time.deltaTime;
        //float xAtual = transform.position.x;
        //xAtual = Mathf.Clamp(xAtual, -limiteEmX, limiteEmX);
        //transform.position = new Vector3(xAtual, transform.position.y, transform.position.z);

    }

    void FixedUpdate()
    {
        rigidBody2D.AddRelativeForce(Vector2.up * _entradaParaImpulso * impulso * Time.deltaTime);
        rigidBody2D.AddTorque(-_entradaParaRotacao * impulsoDeRotacao * Time.deltaTime);

    }

	void OnCollisionEnter2D(Collision2D collision){

		if (quantidadeDeVidas != 0) {
			quantidadeDeVidas--;
		} else {
			Destroy (this.gameObject);
		}
	}



}
