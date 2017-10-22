using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    GameObject HowToPanel;

    private void Start()
    {
        HowToPanel = GameObject.FindGameObjectWithTag("HowTo");

        Invoke("LateStart", 0.1f);
    }

    void LateStart()
    {
        if (HowToPanel != null)
            HowToPanel.SetActive(false);
    }

    public void iniciarJogo()
    {
        SceneManager.LoadScene("Cena1");
    }

    public void sairDoJogo()
    {
        Application.Quit();
    }

    public void comoJogar()
    {

        SceneManager.LoadScene("HowToPlay");
        
    }

    public void comoJogarMenu()
    {

        HowToPanel.SetActive(true);

    }

    public void comoJogarMenuVoltar()
    {

        HowToPanel.SetActive(false);

    }

    public void voltarAoMenu()
    {
     
        SceneManager.LoadScene("Menu Principal");
    }
}
