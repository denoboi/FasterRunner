using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AISpawner : MonoBehaviour
{
    public List<GameObject> AIs = new List<GameObject>();
    private void OnEnable()
    {
       EventManager.OnFirstCountDownEnded.AddListener(SpawnAI);
    }

    private void OnDisable()
    {
        EventManager.OnFirstCountDownEnded.AddListener(SpawnAI);
    }

    private void SpawnAI()
    {
        StartCoroutine(SpawnAICo());
    }

    IEnumerator SpawnAICo()
    {
        yield return new WaitForSeconds(Random.Range(3f,7f));
        foreach (var AI in AIs)
        {
            GameObject ai = Instantiate(AI);
        }
        EventManager.OnSupAIInstantiated.Invoke();

    }
}
