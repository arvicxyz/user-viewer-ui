using System.Collections.ObjectModel;
using System.Linq;

namespace XamApp.Models
{
    public class ObservableGroupCollection<S, T> : ObservableCollection<T>
    {
        public ObservableGroupCollection(IGrouping<S, T> group) : base(group)
        {
            _key = group.Key;
        }

        private readonly S _key;
        public S Key
        {
            get { return _key; }
        }
    }
}
