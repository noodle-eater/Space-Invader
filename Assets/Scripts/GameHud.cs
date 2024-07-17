using System;
using UnityEngine;
using UnityEngine.UI;

namespace NoodleEater
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text healthText;
        [SerializeField] private Text resultText;

        public void SetScore(int score) => scoreText.text = score.ToString();
        public void SetHealth(int health) => healthText.text = "Health: " + health;

        public void HideScore() => scoreText.gameObject.SetActive(false);
        public void HideHealth() => healthText.gameObject.SetActive(false);

        public void SetResult(string text)
        {
            resultText.text = text;
            resultText.gameObject.SetActive(true);
        }
    }
}