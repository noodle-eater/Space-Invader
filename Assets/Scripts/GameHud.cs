using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoodleEater
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text resultText;
        [SerializeField] private List<Image> healths;

        public void SetScore(int score) => scoreText.text = score.ToString();
        public void HideScore() => scoreText.gameObject.SetActive(false);

        public void SetResult(string text)
        {
            resultText.text = text;
            resultText.gameObject.SetActive(true);
        }

        public void SetHealth(int health)
        {
            for (int i = 0; i < healths.Count; i++)
            {
                healths[i].gameObject.SetActive(i < health);
            }
        }
    }
}