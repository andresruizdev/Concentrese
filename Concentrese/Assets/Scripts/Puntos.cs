using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour {
    public Text puntos;
    public static int cant_puntos;
	// Use this for initialization
	void Awake ()
    {
        puntos.text = "Puntos: " + cant_puntos;
	}
	
	// Update is called once per frame
	void Update ()
    {
        puntos.text = "Puntos: " + cant_puntos;
    }
}
