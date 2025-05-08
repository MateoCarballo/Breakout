using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private float speed = 7;
    [SerializeField] private float bound = 7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        //Controlar el movimiento

        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * speed *Time.deltaTime,-bound,bound);
        transform .position = playerPosition;

    }

    public void ResetPlayer()
    {
        transform.position = startPos;
    }
}
