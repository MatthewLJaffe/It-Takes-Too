using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    public string entryName;
    public bool useNextSceneInBuild;

    

    public void loadScene()
    {
        if (Player.instance != null)
        {
            Player.instance.GetComponent<SceneEnter>().entryPointNameToGoTo = entryName;
        }
        Debug.Log("loading into " + entryName);
        if (useNextSceneInBuild)
        {
            loadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
        }
        else
        {
            loadScene(sceneToLoad);
        }
    }

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void loadScene(int ind)
    {
        SceneManager.LoadScene(ind);
    }
}
