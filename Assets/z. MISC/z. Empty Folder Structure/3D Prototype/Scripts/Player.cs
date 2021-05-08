using UnityEngine;

public class Player : MonoBehaviour
{
	private float speed = 10.0f;
	private Rigidbody playerRb;
	private float zBound = 6;

	private float horizontalInput;
	private float verticalInput;
	private float jumpInput;

	// Start is called before the first frame update
	void Start()
	{
		playerRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		jumpInput = Input.GetAxis("Jump");
	}

	private void FixedUpdate()
	{
		playerRb.AddForce(Vector3.forward * speed * verticalInput);
		playerRb.AddForce(Vector3.right * speed * horizontalInput);
		playerRb.AddForce(Vector3.up * speed * jumpInput * 5);
	}
}

