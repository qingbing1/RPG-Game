using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void SceneQuit()
    {
        PlayerPrefs.SetFloat("playerPosX", 17.46f);
        PlayerPrefs.SetFloat("playerPosY", 5.13f);
        PlayerPrefs.SetFloat("playerPosZ", 0.22f);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
