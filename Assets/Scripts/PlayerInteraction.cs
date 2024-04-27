using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameObject interactingWith;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (interactingWith == hit.gameObject)
            return;
        if (hit.gameObject.GetComponent<Interaction>())
        {
            interactingWith = hit.gameObject;
            interactingWith.GetComponent<Interaction>().PerformAction();
        }
    }
}
