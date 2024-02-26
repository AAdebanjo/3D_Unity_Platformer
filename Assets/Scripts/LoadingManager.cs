using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : Singleton<LoadingManager>
{

#if UNITY_EDITOR
    public InspectorButton loadMenu = new InspectorButton("LoadMenuScene");
    public InspectorButton loadGame = new InspectorButton("LoadGameplayScene");
#endif
    public void LoadMenuScene() 
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PlayMenuMusic();
    }
    public void LoadGameplayScene() 
    {
        SceneManager.LoadScene(1);
        AudioManager.instance.PlayGameplayMusic();
    }
    
}
