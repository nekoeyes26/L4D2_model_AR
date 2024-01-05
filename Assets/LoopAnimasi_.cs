using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAnimasi_ : MonoBehaviour
{
    private Animator animator;
    public float delay = 1.0f; // Delay sebelum mengulang animasi

    void Start()
    {
        // Dapatkan referensi ke Animator
        animator = GetComponent<Animator>();

        // Mulai loop animasi setelah delay pertama
        InvokeRepeating("MulaiLoopAnimasi", delay, delay);
    }

    void MulaiLoopAnimasi()
    {
        // Set Trigger untuk memicu transisi ke state yang sama
        animator.SetTrigger("triggerLoop");
    }
}
