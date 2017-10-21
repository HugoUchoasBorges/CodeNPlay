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
    public float rotacaoMaxima;
    public Rigidbody2D rigidBody2D;

    public float topoDaTela;
    public float baseDaTela;
    public float bordaEsquerdaDaTela;
    public float bordaDireitaDaTela;

    public Text textoInimigo;

    // Use this for initialization
    void Start()
    {
        Vector2 impulso = new Vector2(Random.Range(-impulsoMaximo, impulsoMaximo), Random.Range(-impulsoMaximo, impulsoMaximo));
        float rotacao = Random.Range(-rotacaoMaxima, rotacaoMaxima);

        rigidBody2D.AddForce(impulso);
        rigidBody2D.AddTorque(rotacao);

        topoDaTela = 6.2f;
        baseDaTela = -6.2f;
        bordaEsquerdaDaTela = -10.69f;
        bordaDireitaDaTela = 10.69f;
        impulsoMaximo = 200;
        rotacaoMaxima = 200;


        textoInimigo.transform.eulerAngles = Vector3.zero;
        //textoInimigo.transform.rotation.z = 0;



    }

    // Update is called once per frame
    void Update()
    {

        Vector2 posicaoTextoInimigo = textoInimigo.transform.position;
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

        //Vector2 posicaoTexto = transform.position;

        transform.position = novaPosicao;

        //posicaoTextoInimigo = novaPosicao * 20f;

        textoInimigo.transform.position = novaPosicao;

        //posicaoTextoInimigo.x = novaPosicao.x * 20f;
        //posicaoTextoInimigo.y = novaPosicao.y * 20f;
        //textoInimigo.transform.position = novaPosicao * 20.71f;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        pontuacao += 10;
    }
}
