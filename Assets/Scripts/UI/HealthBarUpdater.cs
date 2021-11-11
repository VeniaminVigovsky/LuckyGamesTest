using UnityEngine;
using UnityEngine.UI;
public class HealthBarUpdater : MonoBehaviour
{
    [SerializeField]
    private Entity _entity;

    private int _maxHealth;

    private Image _healthBar;    

    private void Awake()
    {
        _healthBar = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _entity.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _entity.OnHealthChanged -= UpdateHealthBar;
    }

    private void Start()
    {        
        _maxHealth = _entity.MaxHealth;
        _healthBar.fillAmount = 1;
    }

    private void UpdateHealthBar(int newHealth)
    {
        if (_maxHealth == 0) return;

        _healthBar.fillAmount = (float)newHealth / _maxHealth;
    }

    private void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(_entity.transform.position);
    }
}
