using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;

    public void Spawn(GameObject spawnee)
    {
        Vector3 spawnPosition= new Vector3(Random.Range(point1.position.x,point2.position.x),Random.Range(point1.position.y,point3.position.y),0);
        Instantiate(spawnee, spawnPosition, transform.rotation);
    }
}
