using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    private GameObject player;
    public Canvas panel1;
    public Canvas panel2;
    public TMP_Text texto1;
    public bool si = false, no = false, misionAceptada = false;
    public GameObject pared;

    public Button botonSi, botonNo, botonAceptar;
    public GameObject colliders;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.LookAt(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            panel1.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel1.gameObject.SetActive(false);
        }
    }

    public void BotonSi()
    {
        texto1.text = "";
        texto1.text = "Then you know. They are possesed, you have to do something";
        botonSi.gameObject.SetActive(false);
        botonNo.gameObject.SetActive(false);
        botonAceptar.gameObject.SetActive(true);
    }

    public void BotonNo()
    {
        texto1.text = "";
        texto1.text = "They arent better than you, please end with their suffer.";
        botonSi.gameObject.SetActive(false);
        botonNo.gameObject.SetActive(false);
        botonAceptar.gameObject.SetActive(true);
    }

    public void Aceptar()
    {
        pared.gameObject.SetActive(false);
        Destroy(colliders);
        panel2.gameObject.SetActive(true);
    }
}
