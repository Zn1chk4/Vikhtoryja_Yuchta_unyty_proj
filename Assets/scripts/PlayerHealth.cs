using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;

    public Animator anim;
    public bool isDead = false;
    public bool canMove = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health == 0)
        {
            isDead = true;
            canMove = false;

           
            anim.SetBool("IsHurt", false);
            anim.SetBool("IsRun", false);
            anim.SetBool("IsJumping", false);
            anim.SetTrigger("IsDead");
            return; 
        }

      
        anim.SetBool("IsHurt", true);
        StartCoroutine(ResetHurt());
    }


    private IEnumerator ResetHurt()
    {
        canMove = false;
        yield return new WaitForSeconds(0.5f); 
        anim.SetBool("IsHurt", false);
        canMove = true;
    }

}