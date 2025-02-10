using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;


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
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        ResetBall();

    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;

        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);

    }

    public void ResetBall()
    {
        isBallLaunched = false;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        launchIndicator.transform.position = new Vector3(ballAnchor.transform.position.x, ballAnchor.transform.position.y, ballAnchor.transform.position.z + 1f);
    }
}
