using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ToqueCubo : MonoBehaviour
{
    Animation anim;
    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    private void OnMouseDown()
    {
        print("entra");
    }

}
