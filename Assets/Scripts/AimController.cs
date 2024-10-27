using UnityEngine;

public class AimController: MonoBehaviour
{
	[SerializeField] private CharacterController characterController;
	[SerializeField] private LayerMask layerMask;
	[SerializeField] private Transform topBodyOriginRotation;
	[SerializeField] private Transform botBodyOriginRotation;

	private bool needInitRotation = false;
	private RaycastHit wallHit;
	private bool isAimBtnPressed = false;

	public void Update()
	{
		isAimBtnPressed = Input.GetAxisRaw("Fire2") != 0;
	}

	public void FixedUpdate()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (!isAimBtnPressed)
		{
			resetAim();
			return;
		}
		
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
		{
			aim(ref hit);
		}
		else if (hit.point == Vector3.zero && needInitRotation)
		{
			resetAim();
		}
	}

	protected void aim(ref RaycastHit hit)
	{
		topBodyOriginRotation.LookAt(hit.point);

		if (Physics.Linecast(characterController.transform.position, hit.point, out hit, layerMask))
		{
			wallHit = hit;
		}
			
		Debug.DrawLine(characterController.transform.position, wallHit.point, Color.red);
			
		needInitRotation = true;
	}
	
	protected void resetAim()
	{
		topBodyOriginRotation.forward = botBodyOriginRotation.forward;
		needInitRotation = false;
	}
	
}