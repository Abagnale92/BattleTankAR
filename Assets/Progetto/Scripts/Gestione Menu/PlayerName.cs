using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{

    private readonly string defaultName = "Player";
    public GameObject playerLabel;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayerName()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        if (!nickname.Equals(""))
            playerLabel.GetComponent<Text>().text = nickname;
        else
        {
            playerLabel.GetComponent<Text>().text = defaultName;
            PlayerPrefs.SetString("nickname", defaultName);
            PlayerPrefs.Save();
        }
    }

}
