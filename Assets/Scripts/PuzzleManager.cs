using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleManager : MonoBehaviour
{
    public ColorSphere[] spheres;
    public TextMeshProUGUI successText;
    public Button restartButton;
    public AudioSource winSound;

    public void CheckProgress()
    {
        foreach (ColorSphere s in spheres)
        {
            if (!s.IsLocked())
                return;
        }

        // Puzzle complete!
        successText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        if (winSound != null)
            winSound.Play();
    }

    public void RestartPuzzle()
    {
        foreach (ColorSphere s in spheres)
        {
            s.Unlock();
            s.ResetPosition();
        }

        successText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
}

