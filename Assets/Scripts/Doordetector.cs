using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doordetector : MonoBehaviour
{
    public GameObject portal;
    public GameObject portalChecker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            portal.SetActive(true);
            portalChecker.SetActive(true);
        }
    }
}
