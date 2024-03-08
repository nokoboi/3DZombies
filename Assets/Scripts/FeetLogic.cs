using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetLogic : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerStay(Collider other)
    {
        playerController.canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerController.canJump = false;
        Debug.Log("triggerExit");
    }
}
