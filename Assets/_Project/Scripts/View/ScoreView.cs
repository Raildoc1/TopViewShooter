using TMPro;
using TopViewShooter.Core;
using UnityEngine;

namespace TopViewShooter.View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private GameScore _score;
        [SerializeField] private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            DrawScore();
            _score.ScoreChanged += DrawScore;
        }

        private void OnDestroy()
        {
            _score.ScoreChanged -= DrawScore;
        }

        private void DrawScore()
        {
            _textMesh.text = $"{_score.PlayerScore} : {_score.EnemyScore}";
        }
    }
}