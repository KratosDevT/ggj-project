using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    Animator animator;
    [SerializeField] float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 3;
        animator = GetComponent<Animator>();
        animator.SetFloat("multiplier_speed", speed);

    }
}
