using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private CounterModel _model;

    private void OnDisable()
    {
        _model.ChangedCount -= OnUpdateText;
    }

    public void Initialize(CounterModel model)
    {
        _model = model;
        _model.ChangedCount += OnUpdateText;
    }

    public void OnUpdateText(int count)
    {
        _text.text = count.ToString();
    }
}
