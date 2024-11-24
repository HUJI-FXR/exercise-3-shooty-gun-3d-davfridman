using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private LifeTotalScript playerLifeTotal;
    
    // Start is called before the first frame update
    void Start()
    {
        playerLifeTotal = player.GetComponent<LifeTotalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Health: {playerLifeTotal.lifeTotal}/{playerLifeTotal.initialLifeTotal}");
        GetComponent<TMPro.TextMeshProUGUI>().text = 
            $"Health: {playerLifeTotal.lifeTotal}/{Mathf.Round(playerLifeTotal.initialLifeTotal)}";
    }
}
