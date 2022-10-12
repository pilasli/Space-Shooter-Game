using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    //[SerializeField] private GameObject _trippleLaserPowerupPrefab;
    //[SerializeField] private GameObject _speedPowerupPrefab;
    //[SerializeField] private GameObject _shieldPowerupPrefab;
    [SerializeField] private GameObject[] _powerupPrefab;
    [HideInInspector] public int enemyCounter = 0;
    public bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while(_stopSpawning == false)
        {
            if(enemyCounter < 10)
            {
                Vector3 posToSpawnEnemy = new Vector3(Random.Range(-8f,8f), 7, 0);
                GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawnEnemy, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
                enemyCounter++;
            }
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while(_stopSpawning == false)
        {
            Vector3 posToSpawnPowerup = new Vector3(Random.Range(-6f,6f), 7, 0);
            int randomPowerup = Random.Range(0, _powerupPrefab.Length);
            Instantiate(_powerupPrefab[randomPowerup], posToSpawnPowerup, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f,7f));
        }
    }


    public void OnPlayerDead()
    {
        _stopSpawning = true;      
    }
}
