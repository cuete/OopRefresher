using System;
using System.Collections.Generic;

namespace OopRefresher.Operations
{
    class MountainOperations
    {
        public void AddMountain(SmallMountain mountain)
        {

        }

        public static IEnumerable<T> LoadItems<T>()
        {
            string json = GenericMethods.ReadFile("mountains.json");
            IEnumerable<T> items = GenericMethods.DeserializeToObject<T>(json);
            return items;
        }
    }
}
