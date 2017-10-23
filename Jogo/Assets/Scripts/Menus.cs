using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour {

    public GameObject PauseGamePanel;
    public GameObject HowToPanel;
    public GameObject nave;

    void Start()
    {
        PauseGamePanel = GameObject.FindGameObjectWithTag("PAUSA");
        HowToPanel = GameObject.FindGameObjectWithTag("HowTo");

        Invoke("LateStart", 0.01f);
    }

    private void LateStart()
    {
        if (PauseGamePanel != null)
            PauseGamePanel.SetActive(false);

        print(PauseGamePanel == null);
    }

    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("ESC APERTADO");
            menuPausa();
        }
        
    }

    
    public void menuPausa()
    {
        if (PauseGamePanel != null)
        {
            /*if (PauseGamePanel.active)
            {
                desativaMenuPausa();
                return;
            }*/
            ativaMenuPausa();
        }


    }

    public void ativaMenuPausa()
    {
        Debug.Log("AtivaMenuPausa");
        if (PauseGamePanel != null)
        {
            PauseGamePanel.SetActive(true);
            Debug.Log("MENU PAUSA ATIVADO");
        }

        invulneravel();
        CaracteristicasDoJogo.jogoPausado = true;
    }

    public void desativaMenuPausa()
    {

        Debug.Log("Desativa Menu Pausa");
        Debug.Log(PauseGamePanel == null);
        if (PauseGamePanel != null)
        {
            PauseGamePanel.SetActive(false);
            Debug.Log(PauseGamePanel == null);
            Debug.Log("PauseGamePanel desativado");
            //}

            if (HowToPanel != null)
            {
                HowToPanel.SetActive(false);
                Debug.Log("HowToPlay desativado");
            }

            vulneravel();
            CaracteristicasDoJogo.jogoPausado = false;
        }
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
