using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Checks if player has saved a volume preference.
        // If player has a preference, use the one they selected previously.
        // Otherwise, use default (mute set to false).
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            loadMute();
        }
        else
        {
            loadMute();
        }
        SoundIconUpdate();
        AudioListener.pause = muted;
    }

    // When Sound button is clicked, change it to sound on/off.
    public void OnButtonClick()
    {
        if (!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        saveVolumePreference();
        SoundIconUpdate();
    }

    private void SoundIconUpdate()
    {
        if (!muted)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    // If muted is 1, set it to true.
    // If muted is 0, set it to false.
    private void loadMute()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    // Saves the volume preference in "PlayerPrefs".
    private void saveVolumePreference()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }


}
