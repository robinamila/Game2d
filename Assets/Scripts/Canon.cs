using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{

    public GameObject SpawnPoint;
    public GameObject BulletPrefab;
    public float ShootIntervalMin;
    public float ShootIntervalMax;
    //NYT
     public float BulletScaleMin;
     public float BulletScaleMax;
    


    public float Speed = 10;
    
    IEnumerator Start()
    {
        GameObject spawn = Instantiate(BulletPrefab) as GameObject;
        spawn.transform.position = SpawnPoint.transform.position;
        spawn.GetComponent<Rigidbody2D>().velocity = SpawnPoint.transform.right*Speed;


        Destroy(spawn,10);
    spawn.transform.localScale *= Random.Range(BulletScaleMin,BulletScaleMax);
        yield return new WaitForSeconds(Random.Range(ShootIntervalMin,ShootIntervalMax));

        StartCoroutine(Start());

    }

}
