using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads Game Scene to play game
    public void PlayGame() => SceneManager.LoadScene("GameScene");
}
