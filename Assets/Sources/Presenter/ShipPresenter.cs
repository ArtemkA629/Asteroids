using Asteroids.Model;
using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;
    private ShipHealth _shipHealth;

    public void Init(Root init)
    {
        _init = init;
    }

    public void SetShipHealth()
    {
        _shipHealth = _init.Ship.ShipHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_shipHealth.Dead() == false)
            _shipHealth.MinusLife();
        if (collision.gameObject.CompareTag("Enemy") && _shipHealth.Dead())
            _init.DisableShip();
    }
}
