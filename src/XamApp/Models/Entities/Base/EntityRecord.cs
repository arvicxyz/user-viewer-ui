using System.ComponentModel;
using SQLite;

namespace XamApp.Models.Entities
{
    public interface IEntityRecord
    {
        int LocalId { get; set; }
    }

    public class EntityRecord : IEntityRecord, INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int LocalId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T item, T value, string property)
        {
            if (!item.Equals(value))
            {
                item = value;
                NotifyPropertyChanged(property);
            }
        }
    }
}
