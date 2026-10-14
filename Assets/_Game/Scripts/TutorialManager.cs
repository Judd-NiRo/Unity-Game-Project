using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text tutorialText;

    //private float tutorialnumber = 0;

    public GameObject tutorialPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialText.text = "W, A, S, D to move around";
        
        //PlayerPrefs.DeleteKey("TutorialFinished");

        if (PlayerPrefs.GetInt("TutorialFinished", 0) == 1 )
        {
            tutorialPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame || 
        Keyboard.current.aKey.wasPressedThisFrame ||
        Keyboard.current.sKey.wasPressedThisFrame ||
        Keyboard.current.dKey.wasPressedThisFrame)
        {
            tutorialText.text = "Click C to change Camera View";
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            tutorialText.text = "click esc to return to menu \n \n \n Click here to finish tutorial";
        }
        /*
        else if ()
        {
            tutorialbutton.SetActive(false);
            tutorialPanel.SetActive(false);
            tutorialText.gameObject.SetActive(false);
        }
        */
    }

    public void endTutorial()
    {
        PlayerPrefs.SetInt("TutorialFinished", 1);
        PlayerPrefs.Save();

        tutorialPanel.SetActive(false);
    }

    /*
    public void nextTutorial(){

        tutorialnumber ++;

        //if(tutorialnumber == 0){
            
        //}
        if (Keyboard.current.wKey.wasPressedThisFrame || 
        Keyboard.current.aKey.wasPressedThisFrame ||
        Keyboard.current.sKey.wasPressedThisFrame ||
        Keyboard.current.dKey.wasPressedThisFrame)
        {
            tutorialText.text = "Click C to change Camera View";
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            tutorialText.text = "click esc to return to menu";
        }
        else 
        {
            tutorialbutton.SetActive(false);
            tutorialPanel.SetActive(false);
            tutorialText.gameObject.SetActive(false);
        }

    }
    */
}
