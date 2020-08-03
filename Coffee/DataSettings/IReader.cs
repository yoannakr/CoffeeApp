using System.Collections.ObjectModel;

namespace Coffee.DataSettings
{
    public interface IReader
    {
        ObservableCollection<T> ReadData<T>(string fileName);
    }
}
