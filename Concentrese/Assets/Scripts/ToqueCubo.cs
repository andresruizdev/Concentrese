using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ToqueCubo : MonoBehaviour
{
    Animator anim;
    bool hidden = true;
    private void Awake()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        if (hidden)
        {
            hidden = false;

        }
    }

    public void OnMouseDown()
    {
        if (hidden && Comparison.pos < 2)
        {
            PlayAnimation();
            hidden = false;
            Comparison.seleccionados[Comparison.pos] = this.gameObject;
            Comparison.pos++;
        }
        else if (!hidden)
        {
            PlayAnimation();
            hidden = true;
            Comparison.pos--;
        }
        else if (Comparison.pos >= 2)
        {
            anim.SetBool("Block", true);
            Invoke("BlockFalse", 1f);
        }
    }

    public void PlayAnimation()
    {
        anim.SetBool("Showing", hidden);
    }

    void BlockFalse()
    {
        anim.SetBool("Block", false);
    }

}