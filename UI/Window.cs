using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] protected CompositeRoot CompositeRoot;
    [SerializeField] private UIButton _button;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _reward;
    [SerializeField] private TMP_Text _exp;
    [SerializeField] private Slider _progress;
    [SerializeField] private UIButton _shopButton;
    [SerializeField] private UpgradeScreen _upgradeScreen;

    public bool IsShow { get; private set; }

    private void OnEnable()
    {
        IsShow = false;
        _button.Clicked += OnButtonClick;
        _shopButton.Clicked += OnShopButtonClick;
    }

    private void OnDisable()
    {
        _button.Clicked -= OnButtonClick;
        _shopButton.Clicked -= OnShopButtonClick;
    }

    public void Show(int reward, Level level)
    {
        IsShow = true;
        gameObject.SetActive(true);

        var score = level.Exp % level.ValueForLevelUp;

        _level.text = level.Value.ToString();
        _reward.text = reward.ToString();
        _exp.text = level.Exp.ToString() + "/" + level.ValueForLevelUp.ToString();

        _progress.value = (float) score / level.ValueForLevelUp;
    }

    protected abstract void OnButtonClick();

    private void OnShopButtonClick()
    {
        gameObject.SetActive(false);
        _upgradeScreen.Init(this);
        _upgradeScreen.Show();
    }

}
