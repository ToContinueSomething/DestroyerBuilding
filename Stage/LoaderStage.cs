using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Sources
{
    public class LoaderStage : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Canvas _canvas;

        public event Action Finished;

        private float _expectedTime = 2f;
        private float _timer;

        private void Start()
        {
            StartCoroutine(Load());
        }

        private IEnumerator Load()
        {
            var wait = new WaitForSeconds(0.5f);

            while (_timer < _expectedTime)
            {
                _timer += Time.deltaTime;
                float valueSlider = (100 * _timer / _expectedTime) / 100;
                _slider.value = valueSlider;
                yield return null;
            }
            Finished?.Invoke();

            yield return wait;

            _canvas.enabled = false;
        }
    }
}
