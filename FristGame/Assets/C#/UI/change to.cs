using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class changeto : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("Main Scene Easy");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Main Scene Middle");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Main Scene Difficult");
    }
    public void ZCD()
    {
        SceneManager.LoadScene("zhucaidan");
    }

}
