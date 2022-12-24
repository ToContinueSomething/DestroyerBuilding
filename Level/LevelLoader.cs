using System.Collections;
using Agava.YandexGames;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Stage _stage;
    [SerializeField] private SaveLoad _saveLoad;

    private void Awake() => YandexGamesSdk.CallbackLogging = true;

    private IEnumerator Start()
    {
#if UNITY_EDITOR
        _saveLoad.Reset();
        _saveLoad.Load();
        _stage.Load(_saveLoad.GetStage);

        yield break;
#endif

#if UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();

        _saveLoad.Reset();
        _saveLoad.Load();
        _stage.Load(_saveLoad.GetStage);
#endif
    }
}
