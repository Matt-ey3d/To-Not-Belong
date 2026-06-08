using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Collections.Specialized.BitVector32;

public class Animações : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        animator.SetBool("isWalking", move != 0);
        animator.SetFloat("WalkSpeed", 1.5f);
    }
}