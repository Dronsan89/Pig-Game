using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _textCountBomb;
    [SerializeField] private Text _healthPlayerText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject panelLoss;

    public void SetCountBomb() => _textCountBomb.text = $"Count bomb: {DataLevel.CountBomb}";

    public void UpdateHealth() => _healthPlayerText.text = $"HP: {DataLevel.HP}";

    public void UpdateScoreAndLevel()
    {
        _levelText.text = $"Level: {DataLevel.Level}";
        _scoreText.text = $"Score: {DataLevel.Score}";
    }

    public void Loss() => panelLoss.SetActive(true);

    public void RestartLevel()
    {
        DataLevel.ResetAllStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
