using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private Vector2 initialSpeed;
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody2D rb;
    private bool isMoving = false;


    void Start()
    {
        rb = FindFirstObjectByType<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            rb.linearVelocity *= velocityMultiplier;
            GameManager.Instance.BlockDestroyed();
        }
        VelocityFix();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Derrota"))
        {
            //GameManager.Instance.ReloadScene();
            GameManager.Instance.ResetLevel();

        }
    }

    private void Launch()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
            transform.parent = null;
            rb.linearVelocity = initialSpeed;
        }
    }

    private void VelocityFix()
    {
        float velocidadDelta = 0.5f; // Velocidad que queremos que aumente la bola
        float velocidadMinima = 0.2f; // Velocidad m�nima que queremos que tenga la bola

        if (Mathf.Abs(rb.linearVelocity.x) < velocidadMinima) // Si la velocidad de la bola en el eje x es menor que la m�nima
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta; // Elegimos un valor aleatorio entre -0.5 y 0.5
            rb.linearVelocity = new Vector2(rb.linearVelocity.x + velocidadDelta, rb.linearVelocity.y); // Aumentamos la velocidad de la bola
        }

        if (Mathf.Abs(rb.linearVelocity.y) < velocidadMinima) // Si la velocidad de la bola en el eje y es menor que la m�nima
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta; // Elegimos un valor aleatorio entre -0.5 y 0.5
            // Otra forma de aumentar la velocidad (esta vez en el eje y)
            rb.linearVelocity += new Vector2(0f, velocidadDelta); // Aumentamos la velocidad de la bola
        }
    }

    public void ResetBall()
    {
        isMoving = false;
        rb.linearVelocity = Vector3.zero;
        transform.parent = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        transform.position = startPos;
    }
}
