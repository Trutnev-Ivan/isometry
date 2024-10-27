using UnityEngine;

public class RotationController : MonoBehaviour
{
	void Update()
	{
		Vector3 mp = Input.mousePosition;
		float angle = Mathf.Atan2(Screen.height / 2.0f - mp.y, Screen.width / 2.0f - mp.x);
		transform.rotation =
			Quaternion.Euler(transform.eulerAngles.x, Mathf.LerpAngle(transform.eulerAngles.y, 180 - angle * Mathf.Rad2Deg, 10 * Time.deltaTime), transform.eulerAngles.z);
	}
}