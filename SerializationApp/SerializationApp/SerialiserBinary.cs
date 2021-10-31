using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationApp
{
    public class SerialiserBinary : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);

            BinaryFormatter writer = new  BinaryFormatter();
            writer.Serialize(fileStream, item);

            fileStream.Close();
        }
        
        public T DeserialiseFromFile<T>(string filePath)
        {
            Stream fileStream = File.OpenRead(filePath);

            BinaryFormatter reader = new BinaryFormatter();
            var deserialisedItem = (T)reader.Deserialize(fileStream);
            fileStream.Close();
            return deserialisedItem;
        }
        
    }
}
