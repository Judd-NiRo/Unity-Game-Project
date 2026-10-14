using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public Animator PanelDropDown;

    public Animator LaughAnim1;
    public Animator LaughAnim2;
    public Animator LaughAnim3;

    public TMP_Text LoadText;

    public float progress = 0.0f;

    private float timer = 0.0f;
    private float loadTime = 10.0f;

    public GameObject StartGameButton;
    public GameObject ClickHereButton;
    public GameObject LaughingAnimations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartGameButton.SetActive(false);
        ClickHereButton.SetActive(false);
        LaughingAnimations.SetActive(false);
        LoadText.gameObject.SetActive(true);
        StartCoroutine(SceneAsyncLoad("GameScene"));
 
    }

    public void TestButton()
    {
        Debug.Log("BUTTON WORKS BRUUHHHHHHHH");
    }

    IEnumerator SceneAsyncLoad(string scene)
    {
        AsyncOperation syncOp = SceneManager.LoadSceneAsync(scene);
        syncOp.allowSceneActivation = false;

        while (!syncOp.isDone)
        {
            timer += Time.deltaTime;

            progress = Mathf.Clamp01(timer / loadTime);

            LoadText.text = $"Loading: {(int)(progress * 100)} %";

            if (timer >= loadTime)
            {
                syncOp.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void PlayPanelDropDownAnimation(){

        PanelDropDown.Play("MovingPanelAnimation", 0, 0f);
        StartCoroutine(PlayEvery5Seconds());

    }

    IEnumerator PlayEvery5Seconds(){

        while (true)
        {
            LaughAnim1.Play("LaughingAnimation1", 0, 0f);
            LaughAnim2.Play("LaughingAnimation2", 0, 0f);
            LaughAnim3.Play("LaughingAnimation3", 0, 0f);

            yield return new WaitForSeconds(5f);
        }

    }
}
