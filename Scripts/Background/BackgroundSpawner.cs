using UnityEngine;


public class BackgroundSpawner : Spawner<GameBackground>
{
    private int _numberOfInstantiate = 0;

    protected override Prefab InstantiatePrefab()
    {
        _numberOfInstantiate++;

        if (_numberOfInstantiate == 2)
            _numberOfInstantiate = 0;

        return _prefab[_numberOfInstantiate];
    }
}