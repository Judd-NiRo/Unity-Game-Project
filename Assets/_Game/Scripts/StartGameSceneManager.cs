using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGameSceneManager : MonoBehaviour
{
    public float progress = 0.0f;
    private float timer = 0.0f;
    private float loadTime = 4.0f;

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
            //Debug.Log("COROUTINE STARTED");

            timer += Time.deltaTime;

            //Debug.Log("Timer: " + timer);

            progress = Mathf.Clamp01(timer / loadTime);

            if (timer >= loadTime)
            {
                syncOp.allowSceneActivation = true;
            }

            yield return null;

            //Debug.Log("DONE");
        }
    }
}
