using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    public Rigidbody2D rigidBody2D;

    public float impulso;
    public float impulsoDeRotacao;
    private float _entradaParaImpulso;
    private float _entradaParaRotacao;

    public static float topoDaTela;
    public static float baseDaTela;
    public static float bordaEsquerdaDaTela;
    public static float bordaDireitaDaTela;

    // Use this for initialization
    void Start () {

        topoDaTela = 6.18f;
        baseDaTela = -6.18f;
        bordaEsquerdaDaTela = -10.67f;
        bordaDireitaDaTela = 10.67f;
        impulso = 60;
        impulsoDeRotacao = 20;

        rigidBody2D.angularDrag = 0.8f;
        rigidBody2D.drag = 0.3f;

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

        

    }

    void FixedUpdate()
    {
        rigidBody2D.AddRelativeForce(Vector2.up * _entradaParaImpulso * impulso * Time.deltaTime);
        rigidBody2D.AddTorque(-_entradaParaRotacao * impulsoDeRotacao * Time.deltaTime);

    }




}
