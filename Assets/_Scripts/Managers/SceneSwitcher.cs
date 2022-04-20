using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void ChangeScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(scene);
    }
}
