using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Player;

    public float minDist = 50;

    bool followNow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(this.transform.position, Player.transform.position) < minDist)
        {
            transform.LookAt(Player);
            followNow = true;
        }
        if (followNow)
        {
            this.GetComponent<Animator>().Play("Z_Run_InPlace");
            transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, 2 * Time.deltaTime);
        }
    }
}
