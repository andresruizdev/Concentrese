using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comparison : MonoBehaviour
{
    public GameObject mainCamera;
    public static GameObject[] seleccionados = new GameObject[3];
    public static int contSeleccionados = 0;
    public static int cantParejas = 0;
    public List<GameObject> cubes;
    int columns = 4, rows = 5;

    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Facil")
        {
            print(scene.name);
            Camera.main.transform.position = new Vector3(1f, .6f, -10f);
            columns = 2;
            rows = 2;
            cantParejas = 2;
        }
        else if (scene.name == "Normal")
        {
            print(scene.name);
            Camera.main.transform.position = new Vector3(2f, 1f, -10f);
            columns = 3;
            rows = 2;
            cantParejas = 3;
        }
        else if (scene.name == "Dificil1")
        {
            print(scene.name);
            Camera.main.transform.position = new Vector3(2.97f, 2.56f, -10);
            columns = 4;
            rows = 4;
            cantParejas = 8;
        }
        else if (scene.name == "Dificil2")
        {
            print(scene.name);
            Camera.main.transform.position = new Vector3(4f,3.15f,-10f);
            Camera.main.orthographicSize = 6f;
            columns = 5;
            rows = 4;
            cantParejas = 10;
        }
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
