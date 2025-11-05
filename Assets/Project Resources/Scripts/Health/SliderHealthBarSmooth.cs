using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SliderHealthBarSmooth : MonoBehaviour
{
    [SerializeField] private Health Health;
    
    private Slider _slider;

    private Coroutine _coroutine;

    private float _stepIncreaseCoefficient = 1.0f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        Health.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= ChangeValue;
    }

    private void ChangeValue(float currentHealth)
    {
        float fractionMaximumHealth = currentHealth / Health.MaxHealth;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }

        float startPosition = _slider.value;

        _coroutine = StartCoroutine(ChangeState(fractionMaximumHealth, startPosition));
    }

    private IEnumerator ChangeState(float fractionMaximumHealth, float startPosition)
    {
        float step = 0.0f;

        while (Mathf.Approximately(_slider.value, fractionMaximumHealth) == false)
        {
            step = Mathf.Clamp01(step += _stepIncreaseCoefficient * Time.deltaTime);

            _slider.value = Mathf.Lerp(startPosition, fractionMaximumHealth, step);

            yield return null;
        }
    }
}
