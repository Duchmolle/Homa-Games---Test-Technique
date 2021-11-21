using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloFeatureBehaviour : MonoBehaviour
{
    private Animator _soloButtonAnimator;
    [SerializeField] GameObject _soloButtonPrefab;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] float _timeBeforeSpawn;
    [SerializeField] float _timeBeforeDestroy;

    private List<GameObject> _soloButtonsSpawned = new List<GameObject>();
    private float _spawnTimer = 0;
    private float _destroyTimer = 0;

    private bool _objectIsSpawn = false;

    public int _numberOfTargetsHit = 0;
    public bool _haveHitTarget = false;
    private int _numberOfTargetSpawn = 0;

    public bool _soloEventFinished = false;

    public void SoloTime(int numberOfTargetToSpawn)
    {
        if(_numberOfTargetSpawn < numberOfTargetToSpawn)
        {
            _spawnTimer += Time.deltaTime;


            if (_spawnTimer >= _timeBeforeSpawn)
            {
                SpawnSoloElement();
                _spawnTimer = 0;
                _objectIsSpawn = true;
            }

            if (_objectIsSpawn)
            {
                _destroyTimer += Time.deltaTime;

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector3 touchPosToVector3 = new Vector3(touch.position.x, touch.position.y, 0);

                    if (touch.phase == TouchPhase.Moved && (_soloButtonsSpawned[0].transform.position - touchPosToVector3).magnitude < 150)
                    {
                        //_destroyTimer = 0;
                        //_objectIsSpawn = false;
                        _haveHitTarget = true;
                        _soloButtonsSpawned[0].SetActive(false);
                    }
                }

                if (_destroyTimer >= _timeBeforeDestroy)
                {
                    if (_haveHitTarget)
                    {
                        _numberOfTargetsHit++;
                    }

                    DestroySoloElement(_soloButtonsSpawned[0]);
                    _destroyTimer = 0;
                    _objectIsSpawn = false;
                    _haveHitTarget = false;

                    _numberOfTargetSpawn++;
                }
            }
        }

        if(_numberOfTargetSpawn == numberOfTargetToSpawn)
        {
            _soloEventFinished = true;
        }
        
    }

    private GameObject SpawnSoloElement()
    {
        float spawnY = Random.Range(new Vector2(0, 0).y, new Vector2(0, Screen.height).y);
        float spawnX = Random.Range(new Vector2(0, 0).x, new Vector2(Screen.width, 0).x);


        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        GameObject soloButton = Instantiate(_soloButtonPrefab, spawnPosition, Quaternion.identity, transform);

        _soloButtonAnimator = soloButton.GetComponent<Animator>();
        _soloButtonAnimator.SetBool("isSpawning", true);
        _soloButtonsSpawned.Add(soloButton);

        return soloButton;
    }

    private void DestroySoloElement(GameObject soloButtonToDestroy)
    {
        Destroy(soloButtonToDestroy);
        _soloButtonsSpawned.Clear();
    }

}
