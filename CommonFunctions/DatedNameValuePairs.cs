using Core.Interfaces.DataModels;

namespace CommonFunctions
{
    public class DatedNameValuePairs<T> where T : IDatedNameValuePair<T>
    {
        private IEnumerable<T> _datedNameValueTypeInstances;

        public DatedNameValuePairs(IEnumerable<T> datedNameValueTypeInstances)
        {
            _datedNameValueTypeInstances = datedNameValueTypeInstances;
        }

        public T this[string name]
        {
            get
            {
                return this[name, DateOnly.FromDateTime(DateTime.Today)];
            }
        }

        public T this[string name, DateOnly date]
        {
            get
            {
                T value;
                if (_datedNameValueTypeInstances.Count() == 1)
                {
                    value = _datedNameValueTypeInstances.First();
                }
                else
                {
                    var instances = _datedNameValueTypeInstances.Where(lmb => lmb.Name.Equals(name) && lmb.Date <= date).ToList();
                    instances = instances.OrderByDescending(lmb => lmb.Date).ToList();
                    value = instances.First(); // OrDefault();
                }
                return value;
            }
        }

        public IEnumerable<string> Names { get { return _datedNameValueTypeInstances.Select(lmb => lmb.Name).OrderBy(lmb => lmb).Distinct(); } }
    }
}
