using UnityEngine;
using Asteroids.Model;

public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Root _init;

    private int _index;
    private float _secondsPerIndex = 1f;
    private Army _army1, _army2;

    private void Start()
    {
        _army1 = new Army();
        _army2 = new Army();


    }

    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if(newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }
    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 20)
        {
            _factory.CreateNlo(new Nlo(_init.Ship, GetRandomPositionOutsideScreen(), Config.NloSpeed));
            Nlo nlo1 = new Nlo(null, GetRandomPositionOutsideScreen(), Config.NloSpeed);
            Nlo nlo2 = new Nlo(null, GetRandomPositionOutsideScreen(), Config.NloSpeed);
            CreateArmyNlo(nlo1, nlo2, ref _army1);
            CreateArmyNlo(nlo2, nlo1, ref _army2);
        }
        else
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);

            _factory.CreateAsteroid(new Asteroid(position, direction, Config.AsteroidSpeed));
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }

    private void CreateArmyNlo(Nlo nlo, Nlo enemy, ref Army army)
    {
        army.Add(nlo);
        nlo.SetEnemy(enemy);
        _factory.CreateNlo(nlo);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }
}
