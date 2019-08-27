using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameHandler : MonoBehaviour
{

    private readonly string defaultName = "Player";
    public GameObject inputField;

    // Start is called before the first frame update
    void Start()
    {
        SetNickname();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNickname()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        if (!nickname.Equals(""))
            inputField.GetComponent<InputField>().text = nickname;
        else
        {
            inputField.GetComponent<InputField>().text = defaultName;
            PlayerPrefs.SetString("nickname", defaultName);
            PlayerPrefs.Save();
        }
    }

    public void SaveNickname()
    {
        string nickname = inputField.GetComponent<InputField>().text;
        if (nickname.Equals(""))
            nickname = defaultName;
        PlayerPrefs.SetString("nickname", nickname);
        PlayerPrefs.Save();
    }

}
