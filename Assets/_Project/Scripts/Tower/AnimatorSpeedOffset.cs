using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorSpeedOffset : MonoBehaviour
{
    [Header("Animator Speed Settings")]
  
    public float minSpeed = 0.9f;

   
    public float maxSpeed = 1.1f;

 
    public bool randomizeOnAwake = true;

   
    public float fixedSpeed = 0f;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            if (fixedSpeed > 0f)
            {
                animator.speed = fixedSpeed;
            }
            else if (randomizeOnAwake)
            {
                animator.speed = Random.Range(minSpeed, maxSpeed);
            }
        }
    }
}