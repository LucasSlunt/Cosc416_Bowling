using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public float force = 30f;
    public Transform ballAnchor;
    public InputManager inputManager;
    public Rigidbody ballRB;
    public Transform launchIndicator;

    private bool isBallLaunched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        //kinematic means "control this with code, not physics"
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
}
