using UnityEngine;
using UnityEngine.EventSystems;

public class TrafficLight : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TrafficLightCell[] _cells;

    private int _currentIndex;
    private void Start()
    {
        _cells[0].TrafficLightColor.Activate();
    }

    public void OnPointerClick(PointerEventData eventData) => ActivateNextLight();

    private void ActivateNextLight()
    {
        if (_cells != null)
        {
            _cells[_currentIndex].TrafficLightColor.Deactivate();

            if (_currentIndex + 1 < _cells.Length)
            {
                _cells[++_currentIndex].TrafficLightColor.Activate();
            }
            else
            {
                _cells[0].TrafficLightColor.Activate();
                _currentIndex = 0;
            }
        }
    }
}
