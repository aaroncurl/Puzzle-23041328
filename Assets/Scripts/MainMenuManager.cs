using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    private void Awake()
    {
        instance = this;
    }
    public TextMeshProUGUI interactText;
    public GameObject interactTextBox;
    public GameObject questBox;
    private void Start()
    {
        Invoke("QuestDisable", 5);
    }
    void QuestDisable()
    {
        questBox.SetActive(false);
        interactTextBox.SetActive(false);

    }
    public void InterctedWithObject(string text)
    {
        interactTextBox.SetActive(true);
        interactText.text = text;
        Invoke("QuestDisable", 3);
    }

    public void PlayBtn()
    {
        StartCoroutine(loadGame());
    }

    IEnumerator loadGame()
    {
        questBox.SetActive(true);
        yield return new WaitForSeconds(2f);
        questBox.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
