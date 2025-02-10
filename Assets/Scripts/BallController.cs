using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;

    private bool isBallLaunched;

    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();
        
        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;

        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
