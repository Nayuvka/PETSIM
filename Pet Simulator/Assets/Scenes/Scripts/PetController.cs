using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public Animator petAnimator;
    private void Awake()
    {
        
    }

    public void Happy()
    {
        petAnimator.SetTrigger("Happy");
    }

    public void Sad()
    {
        petAnimator.SetTrigger("Sad");
    }

    public void Hungry()
    {
        petAnimator.SetTrigger("Hungry");
    }

    public void Eat()
    {
        petAnimator.SetTrigger("Eat");
    }
}
