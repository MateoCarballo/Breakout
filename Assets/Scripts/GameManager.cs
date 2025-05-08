using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class GameManager : MonoBehaviour
{
    private int blocks;
    public static GameManager Instance { get; private set; }

    public int lifes = 3;

    [SerializeField] private int pointsPerBlock = 10;
    public int points = 0;


    public void LoadBlocks()
    {
        /*
        * Nos devuelve un array con los gameObject que contienen esa etiqueta
        */
        blocks = GameObject.FindGameObjectsWithTag("Block").Length;
    }

    public void BlockDestroyed()
    {
        blocks--;
        points += pointsPerBlock;
        if (blocks <= 0)
        {
            Debug.Log("Nivel completado");
            LoadNextLevel();
        } 
        
    }

    private void Awake()
    {
        //Patrón singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoseLife()
    {
        lifes--;
        //Habría que mostrar este cambio en UI
        if (lifes < 0) {
            Debug.Log("GAME OVER!");
            //cargar escena game over 
        }
        else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        FindFirstObjectByType<Player>().ResetPlayer();
        FindFirstObjectByType<Ball>().ResetBall();
    }
}
