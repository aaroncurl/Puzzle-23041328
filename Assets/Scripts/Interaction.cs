using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Interaction : MonoBehaviour
{

    public enum ObjectType
    {
        door, objects
    };

    public ObjectType type;
    public float openDoorAngle;
    public string messageDisplayed;
    public void PerformAction()
    {
        if (type == ObjectType.door)
            OpenDoor();
        else
            Interact();
    }
    void Interact()
    {
        MainMenuManager.instance.InterctedWithObject(messageDisplayed);
    }
    void OpenDoor()
    {
        transform.Rotate(new Vector3(0, openDoorAngle, 0), Space.Self);
        Debug.Log("rotate");
    }
}
