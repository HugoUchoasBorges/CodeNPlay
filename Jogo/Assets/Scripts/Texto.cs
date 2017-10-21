using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texto : MonoBehaviour {

    public Transform transformInimigo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transformInimigo != null)
            transform.position = transformInimigo.position;

    }
}
