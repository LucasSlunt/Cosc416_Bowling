using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public float force = 30f;
    public Transform ballAnchor;
    public InputManager inputManager;
    public Rigidbody ballRB;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
