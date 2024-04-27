using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject pickuPMsg;
    public GameObject doorOpenMsg;
    public GameObject lybrinth;
    public GameObject Door;
    public GameObject Door2;
    //public GameObject[] allDoors;
    //public GameObject bullet;
    private GameObject key;
    //private GameObject door;

   // public GameObject codePanel;
   // public GameObject jailbox;

    //public Transform firepoint;

    public AudioSource audioSource;
    public AudioClip keyCollect;

    public TimerScript ts;

    public Slider powerBar;

    private string code = "0167";

    public TMP_InputField inputText;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    //public TMP_Text livesText;
    //public TMP_Text keysText;

    bool haskey;
    //bool inDoor;
    bool inkey;

    float currentVal = 0;
    float bulletForce = 7;

    //int lives = 3;
    int totalKeys = 0;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        powerBar.maxValue = 100;
        currentVal = 100;
        powerBar.value = currentVal;

        //livesText.text = "Lives : " + lives.ToString();
        //keysText.text = "Keys : " + totalKeys.ToString();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (inkey&&key)
            {
                Destroy(key);
                haskey = true;
                pickuPMsg.SetActive(false);
                audioSource.PlayOneShot(keyCollect);
                if (ts.timeRemaining >= 60)
                {
                    score += 150;
                }
                else if (ts.timeRemaining < 60 && ts.timeRemaining > 30)
                {
                    score += 100;
                }
                else if (ts.timeRemaining < 30)
                {
                    score += 50;
                }
                scoreText.text ="Score : " + score.ToString();
                if (PlayerPrefs.GetInt("Score", 0) > score)
                {
                    highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("Score", 0).ToString();
                }
                else
                {
                    PlayerPrefs.SetInt("Score", score);
                    highscoreText.text ="HighScore : " + PlayerPrefs.GetInt("Score", 0).ToString();
                }
                Door.SetActive(true);
                this.GetComponent<StarterAssetsInputs>().cursorLocked = false;
                this.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
                if (totalKeys < 4)
                {
                    totalKeys += 1;
                    /*if (totalKeys == 1)
                    {
                        allDoors[0].GetComponent<Animator>().Play("DoorOpen");
                    }
                    else if (totalKeys == 2)
                    {
                        allDoors[0].SetActive(false);
                        allDoors[1].GetComponent<Animator>().Play("DoorOpen");
                    }
                    else if (totalKeys == 3)
                    {
                        allDoors[0].SetActive(false);
                        allDoors[1].SetActive(false);
                        allDoors[2].GetComponent<Animator>().Play("DoorOpen");
                    }
                    else if (totalKeys == 4)
                    {
                        allDoors[0].SetActive(false);
                        allDoors[1].SetActive(false);
                        allDoors[2].SetActive(false);
                        allDoors[3].GetComponent<Animator>().Play("DoorOpen");
                    }*/
                }
                
            }
        }
        /*if (Input.GetKey(KeyCode.E) && inDoor)
        {
            door.GetComponent<Animator>().Play("DoorOpen");

        }
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
        livesText.text = "Lives : " + lives.ToString();
        if (totalKeys < 4)
        {
            keysText.text = "Keys : " + totalKeys.ToString();
        }
        else
        {
            lybrinth.SetActive(true);
        }*/

        if (totalKeys >= 4)
        {
            Door.SetActive(false);
            Door2.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {/*
        if(collision.gameObject.tag == "Jail")
        {
            codePanel.SetActive(true);
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //Destroy(other.gameObject);
            pickuPMsg.SetActive(true);
            inkey = true;
            key = other.gameObject;
        }
        /*if (other.gameObject.tag == "Zombie")
        {
            currentVal -= 10;
            powerBar.value = currentVal;
            if (currentVal <= 0)
            {
                currentVal = 100;
                if (lives > 0)
                {
                    lives -= 1;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
        if (other.gameObject.tag == "Jail")
        {
            codePanel.SetActive(true);
            GetComponent<ThirdPersonController>().stopped = true;
        }
        if (other.gameObject.tag == "Locket")
        {
            doorOpenMsg.SetActive(true);
            inDoor = true;
            door = other.gameObject;
        }*/
    }
    private void OnTriggerStay(Collider other)
    {
        /*if (other.gameObject.tag == "Trap")
        {
            currentVal -= 0.2f;
            powerBar.value = currentVal;
            if (currentVal <= 0)
            {
                currentVal = 100;
                if (lives > 0)
                {
                    lives -= 1;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }*/
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            pickuPMsg.SetActive(false);
            inkey = false;
            key = null;
        }
        if (other.gameObject.tag == "Finish")
        {

            other.gameObject.SetActive(false);

        }

        /*if (other.gameObject.tag == "Locket")
        {
            doorOpenMsg.SetActive(false);
            inDoor = false;
            door = null;
        }*/
    }

    public void enterbtn()
    {
        if (inputText.text == code)
        {
           /* jailbox.SetActive(false);
            codePanel.SetActive(false);*/
            GetComponent<ThirdPersonController>().stopped = false;

        }
        else
        {
            inputText.text = null;
            GetComponent<ThirdPersonController>().stopped = false;

        }
    }

    /*public void shoot()
    {
        GameObject a = Instantiate(bullet, firepoint.position, Quaternion.identity);
        a.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletForce, ForceMode.Impulse);
    }*/

    public void MenuBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void AgainBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
