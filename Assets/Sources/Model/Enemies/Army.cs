using System.Collections.Generic;

namespace Asteroids.Model
{
    public class Army
    {
        private List<Nlo> _nloList;

        public Army()
        {
            _nloList = new List<Nlo>();
        }

        public void Add(Nlo nlo)
        {
            if (_nloList.Contains(nlo) || nlo.InArmy)
                return;
            _nloList.Add(nlo);
            nlo.Destroying += () => RemoveNlo(nlo);
            nlo.SetArmy();
        }

        private void RemoveNlo(Nlo nlo)
        {
            if (!_nloList.Contains(nlo))
                _nloList.Remove(nlo);
        }
    }
}
