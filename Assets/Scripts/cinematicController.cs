using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinematicController : MonoBehaviour
{
    public CinemachineBrain cb;

    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cinematicoff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator cinematicoff()
    {
        cb.enabled = false;
        mainCam.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(40);
        mainCam.GetComponent<Animator>().enabled = false;
        cb.enabled = true;
    }
}
