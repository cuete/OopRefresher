using System.Collections.Generic;

namespace OopRefresher.Interfaces
{
    interface IItem<T>
    {
        void AddItem(List<T> list, T item);
        void ListItems(List<T> list);
        void DeleteItem(List<T> list, string name);
        void EditItem(List<T> list, string name);
        T GetItem(List<T> list, string name);
    }
}
