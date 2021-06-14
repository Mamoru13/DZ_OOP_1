using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alex_Shurukhin
{
    public sealed class GameController : MonoBehaviour
    {
        //private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private Reference _reference;
        public void Awake()
        {
            //_interactiveObject = new ListExecuteObject();
            
            _reference = new Reference();
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            
            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color arge)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
