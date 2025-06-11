using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ColorSphere : MonoBehaviour
{
    public string sphereColor;
    [HideInInspector] public Vector3 originalPosition;
    [HideInInspector] public Quaternion originalRotation;

    private Rigidbody rb;
    private XRGrabInteractable grab;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();
    }

    public void ResetPosition()
    {
        Unlock();

        var interactor = GetComponent<XRGrabInteractable>();
        if (interactor.isSelected)
        {
            interactor.interactionManager.SelectExit(interactor.firstInteractorSelecting, interactor);
        }

        transform.position = originalPosition;
        transform.rotation = originalRotation;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void LockInPlace()
    {
        rb.isKinematic = true;
        grab.enabled = false;
    }

    public void Unlock()
    {
        rb.isKinematic = false;
        grab.enabled = true;
    }

    public bool IsLocked()
    {
        return !grab.enabled;
    }
}
