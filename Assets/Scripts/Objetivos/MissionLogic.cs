using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            }
        }
    }
}
