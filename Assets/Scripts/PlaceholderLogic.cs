using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderLogic : MonoBehaviour
{
    public string requiredColor;
    public AudioSource buzzSound;
    public PuzzleManager puzzleManager;

    private void OnTriggerEnter(Collider other)
    {
        ColorSphere sphere = other.GetComponent<ColorSphere>();
        if (sphere != null)
        {
            if (sphere.sphereColor == requiredColor)
            {
                // Correct placement
                sphere.transform.position = transform.position;
                sphere.LockInPlace();
                puzzleManager.CheckProgress();
            }
            else
            {
                // Wrong placement
                buzzSound?.Play();
                sphere.ResetPosition();
            }
        }
    }
}

