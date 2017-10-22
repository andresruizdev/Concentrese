using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ToqueCubo : MonoBehaviour
{
    public GameObject particulas;
    Animator anim;
    bool showing;
    int x = 0;
    private void Awake()
    {
        try
        {
            anim = transform.parent.GetComponent<Animator>();
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Animator");
        }
        
    }

    private void Update()
    {
        print(x);    
    }

    private void OnMouseDown()
    {
        if (x == 0)
        {
            Mostrar();
        }
        else {
            print("i");
        }
        
    }

    void Mostrar()
    {
        if (!showing  && x == 0 /*&& (Comparison.seleccionados[0] != null || Comparison.seleccionados[1] != null)*/)
        {
            showing = true;
            ShowAnimation();
        }
        else if (showing && x == 0 /* && (Comparison.seleccionados[0] != null || Comparison.seleccionados[1] != null)*/)
        {
            showing = false;
            ShowAnimation();
        }
    }

    void ShowAnimation()
    {
        if (showing)
        {
            anim.SetBool("Show", true);
            if (Comparison.contSeleccionados < 2 && x == 0)
            {
                Comparison.seleccionados[Comparison.contSeleccionados] = this.gameObject;
                Comparison.contSeleccionados++;
                print(Comparison.contSeleccionados);
            }
            if (Comparison.contSeleccionados > 1 && Comparison.seleccionados[0].GetComponent<Renderer>().material.mainTexture == Comparison.seleccionados[1].GetComponent<Renderer>().material.mainTexture)
            {
                Invoke("DeactiveDestroyAnimation", .05f);
                x = 0;
            }

            if (Comparison.contSeleccionados > 1 && (Comparison.seleccionados[0].GetComponent<Renderer>().material.mainTexture != Comparison.seleccionados[1].GetComponent<Renderer>().material.mainTexture ))
            {
                Invoke("DeselectFunction", 1.6f);
            }
        }
        else if (!showing)
        {
            anim.SetBool("Show", false);
            Comparison.contSeleccionados--;
            print(Comparison.contSeleccionados);
        }
    }

    void DeactiveAnimation()
    {
        Comparison.seleccionados[0].transform.parent.GetComponent<Animator>().SetBool("Deactive", true);
        Comparison.seleccionados[1].transform.parent.GetComponent<Animator>().SetBool("Deactive", true);
        Invoke("DeactiveDestroyAnimation", .05f);
    }

    void DeselectFunction()
    {
        Comparison.seleccionados[0].GetComponent<ToqueCubo>().showing = false;
        Comparison.seleccionados[0].transform.parent.GetComponent<Animator>().SetBool("Show", false);
        showing = false;
        anim.SetBool("Show", false);
        Comparison.contSeleccionados = 0;
        
    }

    /*void SameCubes()
    {
        x = 0;
        Destroy(Comparison.seleccionados[0]);
        Destroy(Comparison.seleccionados[1]);
    }*/

    void DeactiveDestroyAnimation()
    {
        for (int i = 0; i < 2; i++)
        {
            Comparison.seleccionados[i].SetActive(false);
            Instantiate(particulas, Comparison.seleccionados[i].transform.position, Quaternion.identity);
        }
        Comparison.contSeleccionados = 0;
    }
}
