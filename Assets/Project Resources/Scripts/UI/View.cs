using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Model _model;

    private void OnDisable()
    {
        _model.ChangedCount -= OnUpdateText;
    }

    public void Initialize(Model model)
    {
        _model = model;
        _model.ChangedCount += OnUpdateText;
    }

    public void OnUpdateText(int count)
    {
        _text.text = count.ToString();
    }
}
