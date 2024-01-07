using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ARInteractionController : MonoBehaviour
{
    private LeanPinchScale pinchScale;
    private LeanTwistRotate twistRotate;
    private animChange animationChanger;

    private bool isTargetFound = false;

    void Start()
    {
        // Dapatkan atau tambahkan komponen LeanPinchScale dan LeanTwistRotate
        pinchScale = GetComponent<LeanPinchScale>();
        twistRotate = GetComponent<LeanTwistRotate>();
        animationChanger = GetComponent<animChange>();

        // Nonaktifkan pinch scale dan twist rotate secara default
        DisablePinchAndRotate();
    }

    void Update()
    {
        // Periksa apakah target sudah ditemukan
        if (isTargetFound)
        {
            // Aktifkan pinch scale dan twist rotate
            EnablePinchAndRotate();
            EnableAnimationChanger();
        }
        else
        {
            // Nonaktifkan pinch scale dan twist rotate
            DisablePinchAndRotate();
            DisableAnimationChanger();
        }
    }

    // Panggil metode ini ketika target ditemukan
    public void OnTargetFound()
    {
        isTargetFound = true;
    }

    // Panggil metode ini ketika target hilang
    public void OnTargetLost()
    {
        isTargetFound = false;
    }

    // Aktifkan pinch scale dan twist rotate
    private void EnablePinchAndRotate()
    {
        if (pinchScale != null)
            pinchScale.enabled = true;

        if (twistRotate != null)
            twistRotate.enabled = true;
    }

    // Nonaktifkan pinch scale dan twist rotate
    private void DisablePinchAndRotate()
    {
        if (pinchScale != null)
            pinchScale.enabled = false;

        if (twistRotate != null)
            twistRotate.enabled = false;
    }

    // Aktifkan animChange.cs
    private void EnableAnimationChanger()
    {
        if (animationChanger != null)
            animationChanger.enabled = true;
    }

    // Nonaktifkan animChange.cs
    private void DisableAnimationChanger()
    {
        if (animationChanger != null)
            animationChanger.enabled = false;
    }
}
