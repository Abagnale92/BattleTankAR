using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartHandler : MonoBehaviour
{

    private readonly string defaultName = "Player";
    public GameObject startButton;
    public GameObject firstProfilePanel;

    // Start is called before the first frame update
    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(StartClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartClicked()
    {
        if (PlayerPrefs.HasKey("nickname"))
        {
            SetPlayerName();
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
            firstProfilePanel.SetActive(true);
    }

    private void SetPlayerName()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        if (!nickname.Equals(""))
            ;
        else
        {
            PlayerPrefs.SetString("nickname", defaultName);
            PlayerPrefs.Save();
        }
    }

}
