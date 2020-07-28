using Coffee.Models;
using System.Collections.Generic;

namespace Coffee.DataSettings
{
    public interface IWriter
    {
        void SaveData<T>(List<T> all, string fileName) where T : Product;
    }
}
