using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparison : MonoBehaviour
{
    public static GameObject[] seleccionados = new GameObject[2];
    public static int contSeleccionados = 0;

    public List<GameObject> cubes;
    int columns = 4, rows = 4;

    void Awake()
    {
        columns *= 2;
        rows *= 2;
        for (int i = 0; i < columns; i+=2)
        {
            for (int j = 0; j < rows; j+=2)
            {
                int index = Random.Range(0, cubes.Count);
                Instantiate(cubes[index], new Vector3(i, j, 0 ), Quaternion.identity);
                cubes.RemoveAt(index);
            }
        }
    }
}
