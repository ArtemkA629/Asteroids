using System;

namespace Asteroids.Model
{
    public class ShipHealth
    {
        private int _health = 3;

        public void MinusLife()
        {
            if (_health <= 0)
                throw new Exception("Жизни отнять нельзя.");
            _health--;
        }

        public bool Dead()
        {
            return _health == 0;
        }

        public int GetLifes()
        {
            return _health;
        }
    }
}
