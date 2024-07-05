using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Image img;
    private bool isBegining = true;
    private bool isDone = false;
    private bool taskDone = false;
    private const float COUNTER = 0.7f;
    public KeyCode keyCode { get; set; } = KeyCode.N;
    public event Action<bool> onFinish;

    void Awake()
    {
        img = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Start()
    {
        if (text) Debug.Log(text.text);
        else Debug.Log("Rayos no text component");
        img.color = Color.white;
        // StartCoroutine(StartMiniGame());
        onFinish += Winner;
    }
    private void Winner(bool asa)
    {
        // Debug.Log("winner " + asa);
    }


    public IEnumerator StartMiniGame()
    {
        text.text = keyCode.ToString();
        yield return StartCoroutine(ChangeAlpha(COUNTER, 0f));
        yield return GameDone(isDone);
        onFinish.Invoke(isDone);
    }

    void Update()
    {
        if (!isBegining) return;
        if (Input.GetKeyDown(keyCode))
        {
            isBegining = false;
            isDone = true;
            taskDone = true;
        }
    }
    public IEnumerator BeginCounter(int counter)
    {
        while (true)
        {
            text.text = counter.ToString();
            yield return new WaitForSeconds(1f);
            counter -= 1;
            if (counter < 0)
            {
                break;
            }
        }
    }
    private IEnumerator ChangeAlpha(float totalTime, float extraTime = 1f)
    {
        float alphaTime = totalTime + extraTime;
        while (true)
        {
            if (taskDone) break;
            alphaTime -= Time.deltaTime;
            if (alphaTime < 0) break;
            Color cc = img.color;
            Color txc = text.color;
            cc.a = alphaTime / totalTime;
            txc.a = alphaTime / totalTime;
            text.color = txc;
            img.color = cc;
            yield return null;
        }
    }
    private IEnumerator ExitAnimation()
    {
        taskDone = false;
        yield return StartCoroutine(ChangeAlpha(1f, 0f));
    }

    private IEnumerator GameDone(bool isDone)
    {
        Color _c;
        if (isDone) _c = Color.green;
        else _c = Color.red;
        _c.a = 0.6f;
        img.color = _c;
        yield return StartCoroutine(ExitAnimation());
    }
}
