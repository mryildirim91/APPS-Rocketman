using System.Collections;
using DG.Tweening;
using Mryildirim.Core;
using Mryildirim.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Mryildirim.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject _gameOverPanel, _instructionsPanel;
        [SerializeField] private Text _endScoreText, _distanceText, _fpsText, _instructionsText;
        [SerializeField] private RectTransform _handTransform;

        private void Start()
        {
            ScoreManager.SetScore(0);
            
            if(!PlayerPrefs.HasKey("Instructions Given"))
                GiveInstructions();
        }
        
        private void Update()
        {
            _distanceText.text = "Distance: " +  ScoreManager.GetScore();
            var fps = 1 / Time.unscaledDeltaTime;
            _fpsText.text = "FPS: " + fps;
        }
        
        public void OpenGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
            ScoreManager.SetHighScore();
            
            if (ScoreManager.GetScore() >= ScoreManager.GetHighScore())
                _endScoreText.text = "New High Score: " + ScoreManager.GetScore();
            else
                _endScoreText.text =
                    "Score: " + ScoreManager.GetScore() + "\n\nHigh Score: " + ScoreManager.GetHighScore();
        }

        private void GiveInstructions()
        {
            _instructionsPanel.SetActive(true);
            StartCoroutine(InstructionsRoutine());
        }

        private IEnumerator InstructionsRoutine()
        {
            _instructionsText.text = "Tap and Hold then Release";
            
            while (!RocketmanMovement.IsLaunched)
            {
                yield return new WaitForSeconds(0.6f);
                _handTransform.DOScale(Vector2.one * 0.5f, 0.5f);
                yield return new WaitForSeconds(0.6f);
                _handTransform.DOScale(Vector2.one, 0.5f);
            }
            
            _instructionsText.text = "Swipe";
            
            while (!RocketmanMovement.IsFloating)
            {
                _handTransform.DOMoveX(Screen.width * 1.05f, 1f).SetEase(Ease.InOutSine);
                yield return new WaitForSeconds(1.1f);
                _handTransform.DOMoveX(-Screen.width * 0.05f, 1f).SetEase(Ease.InOutSine);
                yield return new WaitForSeconds(1.1f);
            }
            
            PlayerPrefs.SetString("Instructions Given", "Instructions Given");
            _instructionsPanel.SetActive(false);
        }
    }
}

