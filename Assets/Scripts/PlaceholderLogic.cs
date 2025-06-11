using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderLogic : MonoBehaviour
{
    public string requiredColor;
    public AudioSource buzzSound;
    public PuzzleManager puzzleManager;
    public Transform snapPoint;

    private void OnTriggerEnter(Collider other)
    {
        ColorSphere sphere = other.GetComponent<ColorSphere>();
        if (sphere != null)
        {
            if (sphere.sphereColor == requiredColor)
            {
                // Correct placement
                sphere.transform.position = snapPoint.position;
                sphere.transform.rotation = snapPoint.rotation;

                sphere.LockInPlace();
                puzzleManager.CheckProgress();
            }
            else
            {
                // Incorrect placement
                if (buzzSound != null)
                    buzzSound.Play();

                sphere.ResetPosition();
            }
        }
    }
}

