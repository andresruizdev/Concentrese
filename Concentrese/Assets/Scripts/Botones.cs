using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour {

	[SerializeField] GameObject canvasMenu;
    [SerializeField] GameObject selectorDificultad;
    [SerializeField] GameObject ganaste;

    public void PlayB()
    {
        canvasMenu.SetActive(false);
        selectorDificultad.SetActive(true);
    }
    
    public void SalirSelectorNiveles()
    {
        selectorDificultad.SetActive(false);
        canvasMenu.SetActive(true);
    }

    public void GanasteSi()
    {
        print(1);
        Comparison.sw = 1;
        ganaste.SetActive(false);
        selectorDificultad.SetActive(true);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void Facil()
    {
        SceneManager.LoadScene(1);
    }

    public void Normal()
    {
        SceneManager.LoadScene(2);
    }

    public void Dificil1()
    {
        SceneManager.LoadScene(3);
    }

    public void Dificil2()
    {
        SceneManager.LoadScene(4);
    }
}
