using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gData;
    public static GameData gameData;
    private bool gameStarted;

    private void Awake()
    {
        gameData = gData;
    }
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            EventManager.gameStarted?.Invoke();
        }

    }

    // Loads main menu
    public void GoToMainMenu() => SceneManager.LoadScene("MainMenu");

   
}
