using UnityEngine;
using System;
using System.Collections;
using RayFire;

[RequireComponent(typeof(RayfireRigid))]
public class Building : MonoBehaviour
{
    private RayfireRigid _rigid;

    public event Action Ruined;

    private const float _percentForRuined = 70f;
    private bool _isEnable = false;

    public bool IsEnable => _isEnable;

    private void OnEnable()
    {
        _rigid = GetComponent<RayfireRigid>();
    }

    public void Enable()
    {
        _isEnable = true;
        StartCoroutine(ContainsPart());
    }

    private IEnumerator ContainsPart()
    {
        var waitForSeconds = new WaitForSeconds(1.5f);

        while (_isEnable)
        {
            if (_rigid.AmountIntegrity <= _percentForRuined)
            {
                Ruined?.Invoke();
                _isEnable = false;
            }

            yield return waitForSeconds;
        }
    }


}
