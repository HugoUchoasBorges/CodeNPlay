using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    public Rigidbody2D rigidBody2D;

    public float impulso;
    public float impulsoDeRotacao;
    private float _entradaParaImpulso;
    private float _entradaParaRotacao;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _entradaParaImpulso = Input.GetAxis("Vertical");
        _entradaParaRotacao = Input.GetAxis("Horizontal");

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




}
