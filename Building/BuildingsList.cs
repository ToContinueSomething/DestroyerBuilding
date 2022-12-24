using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class BuildingsList : MonoBehaviour
{
    [SerializeField] private Level _playerLevel;
    [SerializeField] private int _rewardForOneBuilding = 5;
    [SerializeField] private Transform _container;
    [SerializeField] private PlayerShooting _playerShooting;

    private List<Building> _buildings;

    private int _percentDestroyed = 0;
    private int _rewardForAll;
    private int _countBuildings;

    private const int HundredPercent = 100;
    private const int OneBuilding = 1;

    public event Action<int> PercentChanged;

    public int RewardForAll => _rewardForAll;

    private void Awake()
    {
        _buildings = _container.GetComponentsInChildren<Building>().ToList();
        _countBuildings = _buildings.Capacity;
    }

    private void OnEnable()
    {
        _playerShooting.Shooted += OnPlayerShooted;

        foreach (var building in _buildings)
        {
            building.Ruined += OnBuildingRuined;
        }
    }

    private void OnDisable()
    {
        foreach (var building in _buildings)
        {
            building.Ruined -= OnBuildingRuined;
        }
    }

    private void OnPlayerShooted()
    {
        foreach (var building in _buildings)
            building.Enable();

        _playerShooting.Shooted -= OnPlayerShooted;
    }

    public Transform GetRandomPositionPart()
    {
        int randomIndex = Random.Range(0, _buildings.Count);
        return _buildings[randomIndex].transform;
    }

    private void OnBuildingRuined()
    {
        _rewardForOneBuilding = Random.Range(5, 20);
        _rewardForAll += _rewardForOneBuilding;
        _playerLevel.AddExp(_rewardForOneBuilding);

      _percentDestroyed += HundredPercent * OneBuilding / _countBuildings;

        PercentChanged?.Invoke(_percentDestroyed);
    }
}
