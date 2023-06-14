using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneForestDelayed : MonoBehaviour
{
    private Text storyText;
    private float timeUntilUpdate = 3f;
    private float timeUntilBegin = 30f;
    [SerializeField] private string[] cutsceneText;
    private int cutsceneLength;
    private int counter = 0;
    private float timePassed = 0;
    private bool begin = false;
    public void Start()
    {
        this.storyText = GetComponent<UnityEngine.UI.Text>();
        this.cutsceneLength = cutsceneText.Length;

    }

    public void Update()
    {
        if (begin)
        {
            this.timePassed += Time.deltaTime;
            if (counter < cutsceneLength && this.timePassed > timeUntilUpdate)
            {
                this.storyText.text = cutsceneText[counter];
                counter++;
                this.timePassed = 0;
            }
            else if (counter == this.cutsceneLength)
            {
                this.storyText.text = "";
            }
        }
        else
        {
            this.timePassed += Time.deltaTime;
            if (this.timePassed > timeUntilBegin)
            {
                this.begin = true;
            }
        }

    }


}
