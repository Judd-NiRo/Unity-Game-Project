using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class SavingManager : MonoBehaviour
{
    public TMP_Text LoadText;

    public float progress = 0.0f;

    private float timer = 0.0f;
    private float loadTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SceneAsyncLoad("MenuScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SceneAsyncLoad(string scene)
    {
        AsyncOperation syncOp = SceneManager.LoadSceneAsync(scene);
        syncOp.allowSceneActivation = false;

        while (!syncOp.isDone)
        {
            timer += Time.deltaTime;

            progress = Mathf.Clamp01(timer / loadTime);

            LoadText.text = $"Saving: \n {(int)(progress * 100)} %";

            if (timer >= loadTime)
            {
                syncOp.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
