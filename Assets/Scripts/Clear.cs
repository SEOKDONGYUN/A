using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public bool stageClear = false;
                
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
        if (other.tag == "Player")
        {
            stageClear = true;

            GameManager.instance.OnStageClear();

            SoundManager.instance.PlayClearSound();
            //Debug.Log("ccc");
        }

    }
}
