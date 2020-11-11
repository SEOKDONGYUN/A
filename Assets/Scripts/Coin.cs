using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource coinAudio;
        
    // Start is called before the first frame update
    void Start()
    {
        coinAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
        if (other.tag == "Player")
        {
            GameManager.instance.AddScore(1);

            SoundManager.instance.PlayCoinSound();

            //coinAudio.Play();

            //gameObject.SetActive(false);
            
            Destroy(gameObject, 0.1f);
        }
    }
}
