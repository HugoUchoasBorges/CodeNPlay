using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour {

    public GameObject[] inimigos;

    public int totalInimigos;

    public Transform transformPlayer;

	// Use this for initialization
	void Start () {
        InstanciarInimigos(50);
        
	}
	
	void InstanciarInimigos(int totalInimigos)
    {
        for(int i = 0; i < totalInimigos; i++)
        {
            GameObject inimigoInstanciado = (GameObject)Instantiate(inimigos[0]);
            inimigos[Random.Range(0, inimigos.Length)].transform.position = new Vector3(Random.Range(Nave.bordaEsquerdaDaTela, Nave.bordaDireitaDaTela), Random.Range(Nave.baseDaTela, Nave.topoDaTela), 0);
        }
    }
}
