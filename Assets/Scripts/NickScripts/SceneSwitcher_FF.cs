using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher_FF : MonoBehaviour
{
    //this is a singleton

    public static SceneSwitcher_FF selfInstance;
    public FadeScreen fadeScreen;

    private void Awake()
    {
        if (selfInstance != null && selfInstance != this)
        {
            Destroy(this);
        }
        else
        {
            selfInstance = this;
        }
    }

    public void GoToMainMenu()
    {
        StartCoroutine(WaitDoFadeCoroutine("Main_Menu_FF"));
    }

    public void GoToLevelSelect()
    {
        StartCoroutine(WaitDoFadeCoroutine("Level_Select_FF"));
    }

    public void GoToTutorialLevel()
    {
        StartCoroutine(WaitDoFadeCoroutine("Tutorial_Level_FF"));
    }

    /*
    public void GoToLevelOne()
    {
        SceneManager.LoadScene("WHATEVER_LEVEL_ONE_SCENE_IS_NAMED");
    }
     */

    public void QuitApplication()
    {
        Application.Quit();
    }

    IEnumerator WaitDoFadeCoroutine(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void GoToScene(string sceneName)
    {
        StartCoroutine(GoToSceneRoutine(sceneName));
    }

    IEnumerator GoToSceneRoutine(string sceneName) 
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the next scene
        SceneManager.LoadScene(sceneName);
    }
}
