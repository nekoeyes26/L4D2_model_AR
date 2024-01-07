using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomObserverEventHandler : DefaultObserverEventHandler
{
    private ARInteractionController arInteractionController;

    protected override void Start()
    {
        base.Start();

        // Dapatkan atau tambahkan komponen ARInteractionController
        arInteractionController = GetComponentInChildren<ARInteractionController>();

        // Pastikan ARInteractionController tidak null sebelum digunakan
        if (arInteractionController == null)
        {
            Debug.LogError("ARInteractionController not found in children. Make sure it's attached to the GameObject inside ImageTarget.");
        }
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        // Panggil metode OnTargetFound dari ARInteractionController jika ada
        if (arInteractionController != null)
        {
            arInteractionController.OnTargetFound();
        }
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        // Panggil metode OnTargetLost dari ARInteractionController jika ada
        if (arInteractionController != null)
        {
            arInteractionController.OnTargetLost();
        }
    }
}
