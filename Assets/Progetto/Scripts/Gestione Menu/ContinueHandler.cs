using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueHandler : MonoBehaviour {


    public void OnClick_Gioca()
    {
        SceneManager.LoadScene(1);
    }
}
