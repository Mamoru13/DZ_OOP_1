using UnityEngine;
using UnityEngine.UI;

namespace Alex_Shurukhin
{
    public sealed class Reference
    {
        private GameObject _endGame;
        private GameObject _winGame;
        private Canvas _canvas;
        private Button _restartButton;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        
        public GameObject WinGame
        {
            get
            {
                if (_winGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/WinGameLabel");
                    _winGame = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _winGame;
            }
        }
        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGameLabel");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _endGame;
            }
        }
        
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _restartButton;
            }
        }
        
        
    }
}

