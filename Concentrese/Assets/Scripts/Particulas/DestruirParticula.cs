using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirParticula : MonoBehaviour {
    
    void Start()
    {
        Invoke("DestroyParticule", 2f);
    }

	void DestroyParticule()
    {
        Destroy(gameObject);
	}
}
