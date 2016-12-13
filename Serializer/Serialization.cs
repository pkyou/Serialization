using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    public class Serialization
    {
        public void SerializeToFile<TSource>(TSource source, string path, string name)
        {
            IFormatter formatter = new BinaryFormatter();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Stream stream = new FileStream(path + "\\" + name, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, source);
            stream.Close();
        }

        public TResult Deserialize<TResult>(string path)
        {
            Stream stream = new FileStream(path,
                FileMode.Open, FileAccess.Read, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            TResult result = (TResult)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
