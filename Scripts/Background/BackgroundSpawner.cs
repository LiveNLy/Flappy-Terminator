using UnityEngine;


public class BackgroundSpawner : Spawner<GameBackground>
{
    private int _numberOfInstantiate = 0;
    private int _numberOfSpawned = 2;

    protected override ObjectMover InstantiatePrefab()
    {
        _numberOfInstantiate++;

        if (_numberOfInstantiate == _numberOfSpawned)
            _numberOfInstantiate = 0;

        return _prefab[_numberOfInstantiate];
    }
}