using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody ballRB = other.GetComponent<Rigidbody>();

        float velocityMagnitude = ballRB.linearVelocity.magnitude;

        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;

        ballRB.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);


    }
}
