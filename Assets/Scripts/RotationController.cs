using UnityEngine;
using UnityEngine.InputSystem;

public class RotationController : MonoBehaviour
{
	private Transform transform;
	private Vector2 vec;
	[SerializeField] private LayerMask groundMask;

	void Start()
	{
		transform = GetComponent<Transform>();
		vec = new Vector2(Screen.width / 2, Screen.height / 2);
		Debug.Log("(" + Screen.width + ", " + Screen.height + ")");
	}

	void Update()
	{
		Aim();
	}

	private void Aim()
	{
		Vector3 mp = Input.mousePosition;
		float angle = Mathf.Atan2(Screen.height / 2.0f - mp.y, Screen.width / 2.0f - mp.x);
		Debug.Log(180 - angle * Mathf.Rad2Deg);

		
		
		// transform.rotation = Quaternion.Euler(
		// 	Vector3.Lerp(
		// 		transform.rotation.eulerAngles,
		// 		new Vector3(transform.eulerAngles.x, 180 - angle * Mathf.Rad2Deg, transform.eulerAngles.z),
		// 		10 * Time.deltaTime)
		// 	); 
			
		
		// transform.rotation =
			// Quaternion.Euler(transform.eulerAngles.x, 180 - angle * Mathf.Rad2Deg, transform.eulerAngles.z)
		transform.rotation =
			Quaternion.Euler(transform.eulerAngles.x, Mathf.LerpAngle(transform.eulerAngles.y, 180 - angle * Mathf.Rad2Deg, 10 * Time.deltaTime), transform.eulerAngles.z);

	}
}