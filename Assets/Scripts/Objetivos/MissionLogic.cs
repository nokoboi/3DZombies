using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionLogic : MonoBehaviour
{
    private int numObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonMision;
    
    public void InicializarEnemigos()
    {
        numObjetivos = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        textoMision.text = "Idiots left: " + numObjetivos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemigo")
        {
            Destroy(other.gameObject,3);
            numObjetivos--;
            textoMision.text = "Idiots left: " + numObjetivos;

            if(numObjetivos <= 0)
            {
                textoMision.text = "Idiots erradicated!";
                botonMision.SetActive(true);
            }
        }
    }

    public void BotonOkey()
    {
        SceneManager.LoadScene("Map_v1");
    }
}
