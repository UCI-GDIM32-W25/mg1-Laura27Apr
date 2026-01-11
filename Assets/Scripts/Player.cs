using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _playerTransform = transform;

        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;

        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, y, 0f);
        _playerTransform.position += move * _speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }
    }

    public void PlantSeed ()
    {
        if (_numSeedsLeft <= 0)
            return;

        GameObject plant = Instantiate(_plantPrefab);
        plant.transform.position = _playerTransform.position;

        _numSeedsPlanted++;
        _numSeedsLeft--;

        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }
}
