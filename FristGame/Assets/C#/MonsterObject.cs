using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterObject : jiaohu
{
    public GameObject player, Manager, Maincamera;
    public GameObject AudioMain, AudioFight;

    protected override void Interact()
    {
        Maincamera.SetActive(false);
        Manager.SetActive(true);
        AudioMain.SetActive(false);
        AudioFight.SetActive(true);
        Destroy(gameObject);
    }
}
