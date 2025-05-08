using System.IO.IsolatedStorage;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshPro score;
    [SerializeField] private GameObject[] lifes;
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        score = GameObject.Find("score").GetComponent<TMPro.TextMeshPro>();
        lifes = GameObject.FindGameObjectsWithTag("Life");
        gameManager = gameManager.GetComponent<GameManager>();
        gameManager.LoadBlocks();
    }
    void Start()
    {
        SetScore(gameManager.points);
        SetLifes(gameManager.lifes);

    }

    public void SetScore(int points)
    {
        score.text = points.ToString();

    }
    public void SetLifes(int nLifes)
    {
        foreach (var l in lifes)
        {
            l.SetActive(true);
        }

        for (int i = 0; i < nLifes; i++)
        {
            lifes[i].SetActive(true); 
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
