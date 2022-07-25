using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreRecordView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _date;

    private Image _imageComponent;
    
    public String Number { get; set; }
    public String Score { get; set; }
    public String Date { get; set; }

    private void Awake()
    {
        _imageComponent = GetComponent<Image>();
    }

    public void UpdateTextFields()
    {
        _number.SetText(Number);
        _score.SetText(Score);
        _date.SetText(Date);
    }

    public IEnumerator StartFlickerAnimation()
    {
        while (true)
        {
            _imageComponent.enabled = false;
            yield return new WaitForSeconds(0.8f);
            _imageComponent.enabled = true;
            yield return new WaitForSeconds(0.8f);
        }
    }
}
