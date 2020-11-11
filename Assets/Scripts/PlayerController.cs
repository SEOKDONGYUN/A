using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 300f; // 점프 힘
   public bool isDead = false;

   /*private*/ int jumpCount = 0; // 누적 점프 횟수
   public void inputjump()
    {
        //jumpCount = 0;

        if (isDead)
        {
            return;
        }

        if (jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero; //벨로시티(속도)를 0으로
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); //y값을 점프포스값으로 밀기
            playerAudio.Play(); //오디오 재생
        }
        /*
        else if (playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; //마우스를 떼면 속도를 반값
        }
        */
        animator.SetBool("Grounded", isGrounded); //애니메터에서 만든 불 그라운드 변수를 이즈그라운드 값으로 변경
        
    }

    public void outputjump()
    {
        if (playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; //마우스를 떼면 속도를 반값
        }
    }

   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   //private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() {
        // 초기화
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
   }

   public void Update() {
        // 사용자 입력을 감지하고 점프하는 처리
        if(isDead)
        {
            return;
        }
        /*
        if (inputjump && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero; //벨로시티(속도)를 0으로
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); //y값을 점프포스값으로 밀기
            playerAudio.Play(); //오디오 재생
        }

        else if (!inputjump && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; //마우스를 떼면 속도를 반값
        }
           */
        animator.SetBool("Grounded", isGrounded); //애니메터에서 만든 불 그라운드 변수를 이즈그라운드 값으로 변경
            
   }

   private void Die() {
        // 사망 처리
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip; //데스클립을 오디오로 지정
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero; //속도를 0으로

        isDead = true;

        GameManager.instance.OnPlayerDead();
   }

   private void OnTriggerEnter2D(Collider2D other) {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
        if(other.tag == "Dead" && !isDead) //안전하게 안죽었을때 죽기
        {
            Die();
        }

        if(other.tag == "Clear" && !isDead)
        {
            animator.SetTrigger("Win");
        }
   }

   private void OnCollisionEnter2D(Collision2D col) {
        // 바닥에 닿았음을 감지하는 처리
        if(col.contacts[0].normal.y > 0.7f) //1하늘방향 0벽방향, 경사0.7 넘은 바닥에 닿았을때
        {
            isGrounded = true;
            jumpCount = 0; //바닥에 닿았을때 점프카운트를 0으로
        }
   }

   private void OnCollisionExit2D(Collision2D col) {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }
}