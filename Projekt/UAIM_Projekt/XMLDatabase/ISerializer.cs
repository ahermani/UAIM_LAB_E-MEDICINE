using System;

namespace XMLDatabase
{
    
    using System.Collections.Generic;
    
    public interface ISerializer<T>
    {

        public static IEnumerable<T> Make()
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<T> Deserialize();

        public void SerializeDemo();
        
        public void Serialize(List<T> obj);
    }
}