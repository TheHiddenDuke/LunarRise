using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {
    public float attackCooldown = 0f;
    public float attackSpeed = 1f;
    public float attackDelay = 1f;
    CharacterStats mystats;

    void Start()
    {
        mystats = GetComponent<CharacterStats>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            if (targetStats != null)
            {
                  
                StartCoroutine(DoDamage(targetStats, attackDelay));
                attackCooldown = 1f / attackSpeed;
            
            }
         }
        
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!stats.dead)
        {
            stats.TakeDamage(mystats.damage.getValue());
        }
    }
    

    
}
