using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppClassLibrary.Service
{
    public class DataSerializer
    {
        private readonly string filePath;

        public DataSerializer(string filePath)
        {
            this.filePath = filePath;
        }
        public void Serialize(object data)
        {
            FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(stream, data);
                stream.Close();
                Console.WriteLine("Serialization completed");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during serialization: " + ex.Message);
            }
        }
        public object Deserialize()
        {
            FileStream stream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                object deserializedObject = formatter.Deserialize(stream);
                stream.Close();
                return deserializedObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred during deserialization\n" + ex.Message);
                stream.Close();
                return null;
            }
        }
    }
}
