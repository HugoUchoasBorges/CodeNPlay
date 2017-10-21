using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{

    public string palavra;
    public int pontuacao;

    bool acertarLetra;

    //Variáveis para gerar e movimentar inimigos aleatoriamente
    public float impulsoMaximo;
    public float rotacaoMaxima;
    public Rigidbody2D rigidBody2D; 

    // Use this for initialization
    void Start()
    {
        this.palavra = palavra;

        Vector2 impulso = new Vector2(Random.Range(-impulsoMaximo, impulsoMaximo), Random.Range(-impulsoMaximo, impulsoMaximo));
        float rotacao = Random.Range(-rotacaoMaxima, rotacaoMaxima);

        rigidBody2D.AddForce(impulso);
        rigidBody2D.AddTorque(rotacao);

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        pontuacao += 10;
    }

}
