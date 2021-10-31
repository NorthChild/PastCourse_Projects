using System;

namespace SerializationApp
{
    public class Program
    {
        private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static ISerialise _serialiser;
        static void Main(string[] args)
        {

            //Create Trainee
            Trainee trainee = new Trainee { FirstName = "Cathy", LastName = "French", SpartaNo = 123 };

            var serialiser = new SerialiserBinary();

            // Write trainee to file (binary)
            serialiser.SerialiseToFile($"{_path}/BinaryTrainee.bin", trainee);
            Trainee deserialiseBinaryTrainee = serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryTrainee.bin");

           //XML

            _serialiser = new SerialiserXML();
            
            _serialiser.SerialiseToFile($"{_path}/XMLTrainee.xml", trainee);

            Trainee deserialiseedXMLTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/XMLTrainee.xml");

            Course eng91 = new Course { Title = "Engineering 91", Subject="C# SDET", StartDate = new DateTime(2021, 8, 13) };

            eng91.AddTrainee(trainee);

            eng91.AddTrainee(new Trainee { FirstName = "Martin", LastName = "Beard", SpartaNo = 1243 });

            _serialiser.SerialiseToFile($"{_path}/XMLCourse.xml", eng91);

            var editedCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/XMLCourse.xml");



            //JSON

            _serialiser = new SerialiserJSON();

            _serialiser.SerialiseToFile($"{_path}/JsonTrainee.json", trainee);
            
            Trainee deserialisedJSONTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/JsonTrainee.json");

            _serialiser.SerialiseToFile($"{_path}/JsonCourse.json", editedCourse);

            var editedCourse2 = _serialiser.DeserialiseFromFile<Course>($"{_path}/JsonCourse.json");

        }
    }
}
