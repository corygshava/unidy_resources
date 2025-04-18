// this code was generated by chatGPT AI code generator
using UnityEngine;

public class AudioOnCollision : MonoBehaviour
{
    public AudioSource collisionSound;
    public AudioSource contactSound;
    public float minVelocity = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= minVelocity)
        {
            collisionSound.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= minVelocity)
        {
            contactSound.Play();
        }
    }
}
