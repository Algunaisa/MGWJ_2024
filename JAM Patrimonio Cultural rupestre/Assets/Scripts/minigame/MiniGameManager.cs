using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private List<MiniGameItem> minigameItems;
    [SerializeField] private GameObject minigamePref;
    public int nTries = 5;
    public int wins { get; private set; } = 0;

    void Start()
    {
        // StartCoroutine(LaunchMiniGame());
    }

    public IEnumerator LaunchMiniGame(float launchTime)
    {
        wins = 0;
        yield return new WaitForSeconds(launchTime);
        System.Random random = new System.Random();
        for (int i = 0; i < nTries; i++)
        {
            GameObject _minigameObject = Instantiate(minigamePref, transform);
            MiniGame _mg = _minigameObject.GetComponent<MiniGame>();
            _mg.keyCode = minigameItems[random.Next(minigameItems.Count)].keyCode;
            _mg.onFinish += OnFinish;
            yield return StartCoroutine(_mg.StartMiniGame());
            DestroyImmediate(_minigameObject, true);
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    private void OnFinish(bool isDone)
    {
        if (isDone) wins += 1;
        Debug.Log("WINS " + wins);
    }

    public bool IsWinner()
    {
        return wins == nTries;
    }
}
