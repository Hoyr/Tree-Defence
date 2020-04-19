using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour
{
    public Spawner spawner1;
    public Spawner spawner2;
    int level = 1;
    public GameObject easyEnemy;
    public GameObject mediumEnemy;
    public GameObject hardEnemy;
    public int enemies=0;
    public Text textUI;
    public YourTree tree;
    bool waiting=false;
    public float levelDelay=2;
    // Start is called before the first frame update
    void Start()
    {
        enemies=0;
        waiting=false;
    }

    void SpawnEnemies()
    {
        enemies=0;
        for(int i=0; i<level/2+1; i++)
        {
            spawner1.Spawn(easyEnemy);
            spawner2.Spawn(easyEnemy);
            enemies+=2;
        }
        for(int i=0; i<level/3; i++)
        {
            spawner1.Spawn(mediumEnemy);
            spawner2.Spawn(mediumEnemy);
            enemies+=2;
        }
        for(int i=0; i<level/7; i++)
        {
            if(Random.Range(0,2)==1)
                spawner1.Spawn(hardEnemy);
            else
                spawner2.Spawn(hardEnemy);
            enemies+=1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies==0&&waiting==false)
        {
            Invoke("ResetLevel",levelDelay);
            waiting=true;
        }
        textUI.text="Level: "+level+"\nEnemies: "+enemies;
    }

    void ResetLevel()
    {
        level+=1;
        SpawnEnemies();
        tree.Heal(5);
        waiting=false;
    }

    void FixedUpdate()
    {
        //AstarPath.active.Scan();
    }
}
