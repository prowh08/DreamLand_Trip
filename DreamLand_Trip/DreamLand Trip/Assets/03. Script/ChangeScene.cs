using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void change_MapScene()
    {
        SceneManager.LoadScene("02. Map");
    }
    
    public void change_LoadingScene()
    {
        SceneManager.LoadScene("03. Loading");
    }
}
