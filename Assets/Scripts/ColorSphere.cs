using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ColorSphere : MonoBehaviour
{
    public string sphereColor;
    [HideInInspector] public Vector3 originalPosition;
    private Rigidbody rb;
    private XRGrabInteractable grab;

    void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void LockInPlace()
    {
        rb.isKinematic = true;
        grab.enabled = false;
    }

    public bool IsLocked()
    {
        return !grab.enabled;
    }
}

