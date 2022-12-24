using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Rocket _rocket;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private Counter _bullets;
    [SerializeField] private Stat _strength;
    [SerializeField] private Stage _stage;
    [SerializeField] private Level _playerLevel;

    private const string Money = "Money";
    private const string Strength = "Strength";
    private const string StrengthUpgradeCost = "StrengthUpgradeCost";
    private const string PlayerLevel = "PlayerLevel";
    private const string PlayerValueForLevelUp = "PlayerValueForLevelUp";
    private const string PlayerExp = "PlayerExp";
    private const string Stage = "Stage";
    private const string RopeSkins = "RopeSkins";
    private const string Bullets = "BulletsCounter";
    private const string BulletsUpgradeCost = "BulletsUpgradeCost";

    private const int DefaultLevel = 1;
    private const int DefaultValueForLevelUp = 30;

    public int GetStage => PlayerPrefs.GetInt(Stage, DefaultLevel);

    public void Save()
    {
        PlayerPrefs.SetInt(Money, _wallet.Money);
        PlayerPrefs.SetInt(PlayerLevel, _playerLevel.Value);
        PlayerPrefs.SetInt(PlayerValueForLevelUp, _playerLevel.ValueForLevelUp);
        PlayerPrefs.SetInt(PlayerExp, _playerLevel.Exp);
        PlayerPrefs.SetInt(Stage, _stage.NextStage);
        PlayerPrefs.SetInt(Strength, _strength.Value);
        PlayerPrefs.SetInt(StrengthUpgradeCost, _strength.UpgradeCost);
        PlayerPrefs.SetInt(Bullets,_bullets.Value);
        PlayerPrefs.SetInt(BulletsUpgradeCost,_bullets.UpgradeCost);
    }

    public void Load()
    {
        _progressBar.Init(_stage.NextIndexStage);
        _bullets.Init(PlayerPrefs.GetInt(Bullets,_bullets.DefaultValue),PlayerPrefs.GetInt(BulletsUpgradeCost));
        _wallet.Init(PlayerPrefs.GetInt(Money));
        _strength.Init(PlayerPrefs.GetInt(Strength, _strength.DefaultValue), PlayerPrefs.GetInt(StrengthUpgradeCost));

        _playerLevel.Init(PlayerPrefs.GetInt(PlayerLevel, DefaultLevel),
            PlayerPrefs.GetInt(PlayerExp), PlayerPrefs.GetInt(PlayerValueForLevelUp, _playerLevel.ValueForLevelUp));

        _rocket.Init(PlayerPrefs.GetInt(Bullets,_bullets.DefaultValue));
    }

    public void Reset()
    {
        PlayerPrefs.SetInt(Money, 0);
        PlayerPrefs.SetInt(PlayerLevel, DefaultLevel);
        PlayerPrefs.SetInt(PlayerValueForLevelUp, DefaultValueForLevelUp);
        PlayerPrefs.SetInt(PlayerExp, 0);
        PlayerPrefs.SetInt(Stage, DefaultLevel);
        PlayerPrefs.SetInt(Strength, _strength.DefaultValue);
        PlayerPrefs.SetInt(StrengthUpgradeCost, _strength.StartCost);
        PlayerPrefs.SetInt(RopeSkins, 0);
        PlayerPrefs.SetInt(Bullets, _bullets.DefaultValue);
        PlayerPrefs.SetInt(BulletsUpgradeCost, _bullets.StartCost);
    }
}
