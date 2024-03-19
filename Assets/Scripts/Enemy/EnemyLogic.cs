using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private GameObject player;

    public Animator anim;
    public bool near;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        near = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < 15)
        {
            anim.SetBool("Near", true);
        }
        else
        {
            anim.SetBool("Near", false);
        }

        if(player != null)
        {
            transform.LookAt(player.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fist")
        {
            anim.SetTrigger("Punched");
            Debug.Log("He sido golpeado");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fist")
        {
            anim.SetTrigger("Punched");
            Debug.Log("He sido golpeado");
        }
    }
}
