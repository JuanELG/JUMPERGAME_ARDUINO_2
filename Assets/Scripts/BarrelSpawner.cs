using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    public float respawnTime;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    public void SpawnBarrel()
    {
        Instantiate(barrelPrefab, gameObject.transform.position, Quaternion.identity);
    }

    IEnumerator StartSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnBarrel();   
        }
    }
}
