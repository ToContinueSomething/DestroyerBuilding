using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterUpgradePresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _quantity;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private UIButton _button;
    [SerializeField] private Image _icon;

    private Counter _counter;
    private Action<Counter> _buy;

    private void OnEnable()
    {
        _button.Clicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _button.Clicked += OnButtonClick;
    }

    public void Init(Counter counter,Action<Counter> action)
    {
        _counter = counter;
        _buy = action;
    }

    public void UpdateInfo()
    {
        _name.SetText(_counter.Name);
        _quantity.SetText(_counter.Value.ToString() + "/" + _counter.MaxValue);
        _cost.SetText(_counter.UpgradeCost.ToString());
        _icon.sprite = _counter.Icon;
    }

    private void OnButtonClick()
    {
        _buy(_counter);
    }
}
