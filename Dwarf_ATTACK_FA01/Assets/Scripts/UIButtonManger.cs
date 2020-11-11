using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIButtonManger : MonoBehaviour
{
    GameObject player;
    PlayerController playerScript;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    public void JumpClick()
    {
        Debug.Log("jump");
        playerScript.inputjump();
    }

    public void AtteckClick()
    {
        Debug.Log("Atteck");
    }
}
