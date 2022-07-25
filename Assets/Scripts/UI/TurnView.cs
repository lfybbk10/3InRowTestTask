using TMPro;
using UnityEngine;

public class TurnView : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTurnText(int turns)
    {
        _text.SetText($"Ходов осталось: {turns}");
    }        
}
