using System;
using UnityEngine;
using UnityEngine.UI;

namespace Alex_Shurukhin
{
    public sealed class DisplayWinGame
    {
        private Text _winGameLabel;

        public DisplayWinGame(GameObject endGame)
        {
            _winGameLabel = endGame.GetComponentInChildren<Text>();
            _winGameLabel.text = String.Empty;
        }
        
        public void GameOver(string name, Color color)
        {
            _winGameLabel.text = $"У вас получилось.";
        }
    }
}
