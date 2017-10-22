using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


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

    public void voltarAoMenu()
    {
     
        SceneManager.LoadScene("Menu Principal");
    }
}
