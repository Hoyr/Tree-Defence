using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YourTree : MonoBehaviour
{
    public int maxHP=100;
    public int curHP=100;
    public HealthBar healthbar;
    
    public SoundManager sound;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(maxHP);
        curHP=maxHP;
    }

    public void TakeDamge(int damage)
    {
        curHP-=damage;
        healthbar.SetHealth(curHP);
        if(curHP<=0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void Heal(int amount)
    {
        curHP+=amount;
        if (curHP>maxHP)
            curHP=maxHP;
        healthbar.SetHealth(curHP);
        sound.PlaySound("Heal");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            sound.PlaySound("Damage");
            TakeDamge(enemy.curHP);
            enemy.Die();
        }
    }
}
