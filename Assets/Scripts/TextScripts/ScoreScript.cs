using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    private MonsterSpawnerScript monsterSpawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        monsterSpawnerScript = Terrain.activeTerrain.GetComponent<MonsterSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = 
            $"Score: {monsterSpawnerScript.monsterKilledCount}";
    }
}
