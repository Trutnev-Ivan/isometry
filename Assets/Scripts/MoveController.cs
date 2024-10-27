using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera camera;
    
    private float horizontalMove;
    private float verticalMove;

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = -Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        float moveX = characterController.transform.position.x; 
        float moveZ = characterController.transform.position.z; 
            
        characterController.Move(new Vector3(verticalMove, Physics.gravity.y, horizontalMove) * Time.deltaTime * speed);

        camera.transform.position += new Vector3(characterController.transform.position.x - moveX, 0, characterController.transform.position.z - moveZ);
    }
}
