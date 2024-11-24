using Unity.Android.Types;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private float totalMonsterAmonut = 50f;
    private float currentMonsterCount;
    public float monsterKilledCount=0;
    private Terrain terrain;
    private Vector3 terrainSize, terrainPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrainSize = terrain.terrainData.size;
        terrainPosition = terrain.transform.position;
        currentMonsterCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMonsterCount<totalMonsterAmonut)
        {
            GenerateMonster();
            currentMonsterCount++;
        }
    }

    public void MonsterKilled()
    {
        currentMonsterCount--;
        monsterKilledCount++;
    }

    void GenerateMonster()
    {
        float randomX = Random.Range(terrainPosition.x, terrainPosition.x + terrainSize.x);
        float randomZ = Random.Range(terrainPosition.z, terrainPosition.z + terrainSize.z);
        float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + terrainPosition.y;

        Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);
        GameObject newMonster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        newMonster.tag = "Enemy";
    }
}
