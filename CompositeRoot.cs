using System.Collections;
using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerShooting _player;
    [SerializeField] private InputRouter _input;
    [SerializeField] private LevelCompleteWindow _levelCompleteWindow;
    [SerializeField] private LevelRestartWindow _levelRestartWindow;
    [SerializeField] private BuildingsList _buildingsList;
    [SerializeField] private TextPresenter _walletPresenter;
    [SerializeField] private TextPresenter _playerLevelPresenter;
    [SerializeField] private TextPresenter _bullets;
    [SerializeField] private LevelTask _levelTask;
    [SerializeField] private Level _playerLevel;
    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private Stage _stage;

    private void OnEnable()
    {
        _player.BulletChanged += OnBulletChanged;
        _buildingsList.PercentChanged += OnBuildingPercentChanged;
    }

    private void OnDisable()
    {
        _player.BulletChanged -= OnBulletChanged;
        _buildingsList.PercentChanged -= OnBuildingPercentChanged;
    }

    private void Start()
    {
        _saveLoad.Load();
    }

    public void LoadNextLevel()
    {
        _saveLoad.Save();
        _stage.LoadNext();
    }

    public void LoadCurrentLevel()
    {
        _saveLoad.Save();
        _stage.LoadCurrent();
    }

    private void OnBulletChanged(int bullets)
    {
        _bullets.UpdateData(bullets);

        if (bullets <= 0)
        {
            _buildingsList.enabled = false;
            StartCoroutine(TryOpenRestartWindow());
        }
    }

    private void OnBuildingPercentChanged(int percent)
    {
        _levelTask.UpdateInfo(percent);

        if (_levelTask.IsComplete)
        {
            CompleteGame(_levelCompleteWindow);
            _buildingsList.enabled = false;
        }
    }

    private void CompleteGame(Window window)
    {
        _input.Disable();

        int money = _buildingsList.RewardForAll;
        _wallet.AddMoney(money);

        _playerLevelPresenter.UpdateData(_playerLevel.Value);
        _walletPresenter.UpdateData(_wallet.Money);

        window.Show(money, _playerLevel);
        _saveLoad.Save();
    }

    private IEnumerator TryOpenRestartWindow()
    {
        if(_levelCompleteWindow.IsShow)
            yield break;

        yield return new WaitForSeconds(5f);

        CompleteGame(_levelRestartWindow);
    }
}
