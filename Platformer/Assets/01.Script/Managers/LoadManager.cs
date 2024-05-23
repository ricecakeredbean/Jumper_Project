using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : Singleton<LoadManager>
{
    public void LoadStage1()
    {
        SceneManager.LoadScene(1);
    }
}
