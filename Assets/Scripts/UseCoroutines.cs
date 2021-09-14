using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoroutines : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(CloneEnemyPrefab());
    }

    IEnumerator CloneEnemyPrefab()
    {
        while (true) 
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4.0f);
        }
    }
}
