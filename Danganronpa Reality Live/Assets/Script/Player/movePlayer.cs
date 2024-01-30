using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float speed_Move = 0.5f;

    private float xMove;
    private float zMove;
    private Vector3 shakePos;
    private Vector3 moveDirection;
    private CharacterController player;
    private FreezePlayer _freezePlayerComponent;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        _freezePlayerComponent = GetComponent<FreezePlayer>();

        if (_freezePlayerComponent != null)
            _freezePlayerComponent.ToMove += Move;
        if (player != null)
            shakePos = player.transform.position;
    }

    private void Update()
    {
        UseGravityforPlayer();
    }

    private void OnDisable()
    {
        _freezePlayerComponent.ToMove -= Move;
    }

    private void Move()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");

        if (player.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0f, zMove);
            moveDirection = transform.TransformDirection(moveDirection);
            if (moveDirection.sqrMagnitude > 1)
            {
                moveDirection.Normalize();
            }
        }
        player.Move(moveDirection * speed_Move * Time.deltaTime);
        //Debug.Log("??? ?:" + x_Move);
        //Debug.Log("??? Z:" + z_Move);
        moveDirection.y -= 0.2f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.Move(moveDirection * speed_Move * 2 * Time.deltaTime);
        }
    }
    private void UseGravityforPlayer()
    {
        if (player.transform.position.y < -10f)
            player.transform.position = shakePos;
    }
}