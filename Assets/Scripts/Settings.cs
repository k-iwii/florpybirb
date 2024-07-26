using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Sprite muteImage;
    public Sprite unmuteImage;
    public Button muteButton;
    public static bool isMuted = false;
    void Start()
    {
        isMuted = false;
        muteButton.image.sprite = muteImage;
    }

    public void mutePressed() {
        isMuted = !isMuted;

        if (isMuted) {
            muteButton.image.sprite = unmuteImage;
        } else {
            muteButton.image.sprite = muteImage;
        }
    }
}
