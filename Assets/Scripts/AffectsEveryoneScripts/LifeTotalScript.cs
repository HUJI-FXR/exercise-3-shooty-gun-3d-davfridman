using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LifeTotalScript : MonoBehaviour
{
    [SerializeField] public float initialLifeTotal = 10f;
    public float lifeTotal;
    private MonsterSpawnerScript monsterSpawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        monsterSpawnerScript = Terrain.activeTerrain.GetComponent<MonsterSpawnerScript>();
        lifeTotal = initialLifeTotal;
    }

    public void DecreaseLife(float decreaseBy)
    {
        lifeTotal-=decreaseBy;
    }
    public void IncreaseLife(float increaseBy)
    {
        lifeTotal+=increaseBy;
    }
    public float GetLeftLifeRatio()
    {
        float temp = lifeTotal/initialLifeTotal;
        if(temp<=0)
            return 0;
        return lifeTotal/initialLifeTotal;
    }
    // Update is called once per frame
    void Update()
    {
        if(lifeTotal <= 0)
        {
            if(gameObject.tag=="Enemy"){
                monsterSpawnerScript.MonsterKilled();
            }
            Destroy(gameObject);


        }
    }
}
