using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ToqueCubo : MonoBehaviour
{
    Animator anim;
    bool showing;
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
    private void OnMouseDown()
    {
        Mostrar();
    }

    void Mostrar()
    {
        if (!showing)
        {
            showing = true;
            ShowAnimation();
        }
        else if (showing)
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
            if (Comparison.contSeleccionados < 2)
            {
                Comparison.seleccionados[Comparison.contSeleccionados] = this.gameObject;
                Comparison.contSeleccionados++;
                print(Comparison.contSeleccionados);
            }
            if (Comparison.contSeleccionados > 1 && Comparison.seleccionados[0].GetComponent<Renderer>().material.mainTexture == Comparison.seleccionados[1].GetComponent<Renderer>().material.mainTexture)
            {
                //anim.SetBool("Destroy", true);
                Invoke("DestroyAnimation",1.2f);
                Invoke("SameCubes", 2.2f);
                Comparison.contSeleccionados = 0;
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

        /*if (compare.contSeleccionados < 2 && show)
        {
            Comparison.seleccionados[Comparison.contSeleccionados] = this.gameObject;
            print(Comparison.seleccionados[Comparison.contSeleccionados]);
            Comparison.contSeleccionados++;
            print(Comparison.contSeleccionados);
            if (Comparison.contSeleccionados > 1 && Comparison.seleccionados[0].GetComponent<Renderer>().material.mainTexture.name == Comparison.seleccionados[1].GetComponent<Renderer>().material.mainTexture.name )
            {
                //anim.SetBool("Destroy", true);
                Comparison.seleccionados[0].transform.parent.GetComponent<Animator>().SetBool("Destroy", true);
                Comparison.seleccionados[1].transform.parent.GetComponent<Animator>().SetBool("Destroy", true);
                Invoke("SameCubes", 1f);
                Comparison.contSeleccionados = 0;
            }
            else if (Comparison.contSeleccionados > 1 && Comparison.seleccionados[0].GetComponent<Renderer>().material.mainTexture.name != Comparison.seleccionados[1].GetComponent<Renderer>().material.mainTexture.name)
            {
                Comparison.seleccionados[0].transform.parent.GetComponent<Animator>().SetBool("Show", false);
                Comparison.seleccionados[1].transform.parent.GetComponent<Animator>().SetBool("Show", false);
                Comparison.contSeleccionados = 0;
            
        }
        else if (Comparison.contSeleccionados < 2 && !show)
        {
            Comparison.contSeleccionados--;
            print(Comparison.contSeleccionados);
        }
        */
    }

    void DestroyAnimation()
    {
        Comparison.seleccionados[0].transform.parent.GetComponent<Animator>().SetBool("Destroy", true);
        Comparison.seleccionados[1].transform.parent.GetComponent<Animator>().SetBool("Destroy", true);
    }

    void DeselectFunction()
    {
        Comparison.seleccionados[0].GetComponent<ToqueCubo>().showing = false;
        Comparison.seleccionados[0].transform.parent.GetComponent<Animator>().SetBool("Show", false);
        showing = false;
        anim.SetBool("Show", false);
        Comparison.contSeleccionados = 0;
        
    }

    void SameCubes()
    {
        Destroy(Comparison.seleccionados[0]);
        Destroy(Comparison.seleccionados[1]);
    }
}
