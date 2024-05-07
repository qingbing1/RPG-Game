using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReturn : MonoBehaviour
{
    public float PlayerPosX = 17.46f;
    public float PlayerPosY = 4.62f;
    public float PlayerPosZ = 0.22f;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosX = PlayerPrefs.GetFloat("playerPosX");
        PlayerPosY = PlayerPrefs.GetFloat("playerPosY");
        PlayerPosZ = PlayerPrefs.GetFloat("playerPosZ");
        if (PlayerPosX == 0.0f)
        {
            gameObject.transform.position = new Vector3(0f, 0f, 0f);
        }
        if (PlayerPosX != 0.0f)
        {
            gameObject.transform.position = new Vector3(PlayerPosX, PlayerPosY, PlayerPosZ);
        }
    }
}




