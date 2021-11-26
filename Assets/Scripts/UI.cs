using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _winScreen;
    
    private void OnEnable()
    {
        GameLogic.WonEvent += OnWon;
        Car.GameOverEvent += OnGameOver;
    }

    private void OnDisable()
    {
        GameLogic.WonEvent -= OnWon;
        Car.GameOverEvent -= OnGameOver;
    }
    
    private void OnGameOver() => _gameOverScreen.SetActive(true);
    private void OnWon() => _winScreen.SetActive(true);
}
