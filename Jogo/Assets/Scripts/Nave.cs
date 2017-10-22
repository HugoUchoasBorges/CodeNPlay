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

    public bool morto;

    public Color corInvencibilidade;
    public Color corNormal;

    public GameObject game_over_panel;

    // Use this for initialization
    void Start() {

        game_over_panel.SetActive(false);

        topoDaTela = 6.18f;
        baseDaTela = -6.18f;
        bordaEsquerdaDaTela = -10.67f;
        bordaDireitaDaTela = 10.67f;
        impulso = 300;
        impulsoDeRotacao = 300;

        rigidBody2D.angularDrag = 0.8f;
        rigidBody2D.drag = 0.3f;

    }

    // Update is called once per frame
    void Update() {

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
        //rigidBody2D.AddTorque(-_entradaParaRotacao * impulsoDeRotacao * Time.deltaTime);
		//rigidBody2D.AddRelativeForce(Vector2.up * _entradaParaImpulso * impulso * Time.deltaTime);
		rigidBody2D.transform.Rotate(Vector3.forward* -_entradaParaRotacao * impulsoDeRotacao * Time.deltaTime);

    }

    void reviver()
    {
        rigidBody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        SpriteRenderer renderizadorDeSprite = GetComponent<SpriteRenderer>();
        renderizadorDeSprite.enabled = true;
        renderizadorDeSprite.color = corInvencibilidade;

        Invoke("vulneravel", 3f);
        morto = false;
    }

    public void vulneravel()
    {

        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = corNormal;

        GameObject PauseGamePanel = GameObject.FindGameObjectWithTag("PAUSA");
        if (GameObject.FindGameObjectWithTag("PAUSA") != null)
            if (PauseGamePanel.activeSelf == true)
            {
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = corInvencibilidade;
            }
                
            
    }

    public void invulneravel()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = corInvencibilidade;
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        /*lives--;
        lives_text.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }*/

        CaracteristicasDoJogo.totalVidas--;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        

        Invoke("reviver", 2f);
        if (CaracteristicasDoJogo.totalVidas <= 0)
        {
            morto = true;
            fimDeJogo();
        }
        
    }

    void fimDeJogo()
    {
        CancelInvoke("reviver");
        game_over_panel.SetActive(true);
        //Debug.Log("JOGADOR MORREU  !!! ");
    }

}



