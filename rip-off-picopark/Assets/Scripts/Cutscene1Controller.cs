using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cutscene1 : MonoBehaviour
{
    private Text storyText;
    private float timeUntilUpdate = 3;
    [SerializeField] private string[] cutsceneText;
    private int cutsceneLength;
    private int counter = 0;
    private float timePassed = 0;
    public void Start()
    {
        this.storyText = GetComponent<UnityEngine.UI.Text>();
        this.cutsceneLength = cutsceneText.Length;

    }

    public void Update()
    {
        this.timePassed += Time.deltaTime;
        if (counter < cutsceneLength && this.timePassed > timeUntilUpdate)
        {
            this.storyText.text = cutsceneText[counter];
            counter++;
            this.timePassed = 0;
        }
        else if(counter == this.cutsceneLength)
        {
            this.storyText.text = "";
        }
    }


    
}
