using System.Collections;
using UnityEngine;

namespace LTF.CustomWaits
{
    [System.Serializable]
    public class CustomRandomWaitForSeconds : IEnumerator
    {
        [SerializeField] private Vector2 _waitTimeRange;
        private float _waitTime;
        private float _elapsedTime = 0f;

        public CustomRandomWaitForSeconds() { }

        public CustomRandomWaitForSeconds(Vector2 waitTimeRange)
        {
            _waitTimeRange = waitTimeRange;
            _waitTime = (waitTimeRange.x + waitTimeRange.y) * .5f;
        }

        public object Current => null;

        public bool MoveNext()
        {
            _elapsedTime += Time.deltaTime;
            bool flag = _elapsedTime < _waitTime;
            if (!flag)
                Reset();

            return flag;
        }

        public void Reset()
        {
            _elapsedTime = 0f;
            _waitTime = Random.Range(_waitTimeRange.x, _waitTimeRange.y);
        }
    }
}
