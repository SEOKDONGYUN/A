using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamge = 100;

    public float attackRate = 2f;
    float nextAttacktime = 0f;

    public void inputAttak()
    {
        var playerController = /*GameObject.Find("Dwarf").*/GetComponent<PlayerController>(); //다른스크립트의 (퍼블릭)변수,함수 쓰기
        if (playerController.isDead) //콘트롤러의 이즈데드를 사용함
        {
            return;
        }

        if (Time.time >= nextAttacktime)
        {
            Attack();
                nextAttacktime = Time.time + 1f / attackRate;
        }
    }


        // Update is called once per frame
        void Update()
    {
        var playerController = /*GameObject.Find("Dwarf").*/GetComponent<PlayerController>(); //다른스크립트의 (퍼블릭)변수,함수 쓰기
        if (playerController.isDead) //콘트롤러의 이즈데드를 사용함
        {
            return;
        }
        
        if (Time.time >= nextAttacktime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttacktime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamege(attackDamge);

            //Debug.Log("We hit" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
