using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyContainer;
    private bool _isSpawning = true;

    IEnumerator SpawnRoutine(){
        while(_isSpawning == true){
            Vector3 spawnPoint = transform.position;
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(){
        _isSpawning = false;
    }
}
