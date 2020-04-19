using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP=100;
    public int curHP=100;
    // Start is called before the first frame update
    void Start()
    {
        curHP=maxHP;
    }

    public void TakeDamage(int damage)
    {
        curHP-=damage;
        if(curHP<=0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.Find("GameRunner").GetComponent<GameRunner>().enemies-=1;
        Destroy(gameObject);
    }
}
