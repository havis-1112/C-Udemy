using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace IoSerializationEncoding
{
    internal class Program
    {
        [Serializable]
        public class Country
        {
            public short CountryID { get; set; }
            public string CountryName { get; set; }
            public long Population { get; set; }
            public string Region { get; set; }
        }

        [Serializable]
        public class Continent
        {
            public string ContinentName { get; set; }
            public List<Country> Countries { get; set; }
        }

        [Serializable]
        public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            /*
                number systems

                binary       - base 2
                decimal      - base 10
                hexadecimal  - base 16
                octal        - base 8
            */

            /*
                ascii vs unicode

                ascii:
                - 7 bit character encoding
                - supports 128 characters
                - english letters, digits, symbols
                - example:
                    'A' -> 65
                    'a' -> 97

                unicode:
                - universal character encoding
                - supports all world languages
                - includes ascii characters
                - supports tamil, hindi, emojis
                - example:
                    'A' -> U+0041
                    'அ' -> U+0B85

                note:
                - ascii is a subset of unicode
                - modern languages use unicode by default
            */

            // binary

            int decBinary = 13;
            string binary = Convert.ToString(decBinary, 2);
            Console.WriteLine(binary);

            int binaryToDec = Convert.ToInt32(binary, 2);
            Console.WriteLine(binaryToDec);

            int binaryLiteral = 0b1100100; // 100
            Console.WriteLine(binaryLiteral);


            // octal

            int decOctal = 289;
            string octal = Convert.ToString(decOctal, 8);
            Console.WriteLine(octal);

            int octalToDec = Convert.ToInt32(octal, 8);
            Console.WriteLine(octalToDec);


            // hexadecimal

            int decHex = 742;
            string hex = Convert.ToString(decHex, 16);
            Console.WriteLine(hex);

            int hexToDec = Convert.ToInt32(hex, 16);
            Console.WriteLine(hexToDec);

            int hexLiteral = 0x64; // 100
            Console.WriteLine(hexLiteral);


            // ascii 

            char ch = 'A';
            byte asciiByte = (byte)ch;
            Console.WriteLine(asciiByte); // 65

            char ch2 = (char)asciiByte;
            Console.WriteLine(ch2); // A

            byte[] asciiBytes = new byte[128];
            for (byte i = 0; i < 128; i++)
            {
                asciiBytes[i] = i;
            }

            Console.OutputEncoding = Encoding.ASCII;
            string asciiTable = Encoding.ASCII.GetString(asciiBytes);
            Console.WriteLine(asciiTable);

            string asciiSentence = "The quick brown fox jumps over the lazy dog";
            byte[] asciiSentenceBytes = Encoding.ASCII.GetBytes(asciiSentence);
            string asciiSentenceBack = Encoding.ASCII.GetString(asciiSentenceBytes);
            Console.WriteLine(asciiSentenceBack);


            // unicode

            string unicodeChar1 = "ﺱ";
            Console.WriteLine(unicodeChar1);

            string unicodeChar2 = "\u0543";
            Console.WriteLine(unicodeChar2);

            string unicodeSentence = "The quick brown fox jumps over the lazy dog";
            byte[] unicodeBytes = Encoding.Unicode.GetBytes(unicodeSentence);
            string unicodeSentenceBack = Encoding.Unicode.GetString(unicodeBytes);
            Console.WriteLine(unicodeSentenceBack);

            // =========================
            // 1. FILE CLASS (Static)
            // =========================
            string file1 = @"c:\practice\India.txt";
            string file2 = @"c:\practice\India2.txt";
            string file3 = @"c:\practice\another.txt";

            File.Create(file1).Close();
            Console.WriteLine("India.txt created");

            if (File.Exists(file1))
            {
                File.Copy(file1, file2, true);
                Console.WriteLine("India.txt copied to India2.txt");

                File.Move(file2, file3, true);
                Console.WriteLine("India2.txt moved to another.txt");

                File.Delete(file3);
                Console.WriteLine("another.txt deleted");
            }

            // =========================
            // 2. FILE + COLLECTION
            // =========================
            List<string> asia = new List<string> { "Russia", "China", "India" };
            string asiaFile = @"c:\practice\asia.txt";

            File.WriteAllLines(asiaFile, asia);
            Console.WriteLine("asia.txt created");

            string[] lines = File.ReadAllLines(asiaFile);
            foreach (string line in lines)
                Console.WriteLine(line);

            // =========================
            // 3. FILEINFO (OOP)
            // =========================
            string japanFile = @"c:\practice\japan.txt";
            string copyFile = @"c:\practice\copy.txt";
            string moveFile = @"c:\practice\moved.txt";

            FileInfo fileInfo = new FileInfo(japanFile);

            fileInfo.Create().Close();
            Console.WriteLine("japan.txt created");

            FileInfo copied = fileInfo.CopyTo(copyFile, true);
            Console.WriteLine("copy.txt created");

            copied.MoveTo(moveFile);
            Console.WriteLine("copy.txt moved to moved.txt");

            copied.Delete();
            Console.WriteLine("moved.txt deleted");

            // =========================
            // 4. FILEINFO PROPERTIES
            // =========================
            if (fileInfo.Exists)
            {
                Console.WriteLine("\nFileInfo Properties:");
                Console.WriteLine("FullName: " + fileInfo.FullName);
                Console.WriteLine("Name: " + fileInfo.Name);
                Console.WriteLine("Directory: " + fileInfo.DirectoryName);
                Console.WriteLine("Extension: " + fileInfo.Extension);
                Console.WriteLine("Size: " + fileInfo.Length + " bytes");
                Console.WriteLine("Created: " + fileInfo.CreationTime);
            }

            // =========================
            // 5. DIRECTORY (Static)
            // =========================
            string countriesPath = @"c:\practice\countries";
            Directory.CreateDirectory(countriesPath);

            foreach (string c in new[] { "India", "UK", "USA" })
                Directory.CreateDirectory(Path.Combine(countriesPath, c));

            string[] countryFiles = { "capitals.txt", "sports.txt", "population.dat" };
            foreach (string f in countryFiles)
                File.Create(Path.Combine(countriesPath, f)).Close();

            string worldPath = @"c:\practice\world";
            Directory.Move(countriesPath, worldPath);

            Console.WriteLine("\nText files:");
            foreach (string f in Directory.GetFiles(worldPath, "*.txt"))
                Console.WriteLine(f);

            Console.WriteLine("\nSub folders:");
            foreach (string d in Directory.GetDirectories(worldPath))
                Console.WriteLine(d);

            Directory.Delete(worldPath, true);
            Console.WriteLine("world folder deleted");

            // =========================
            // 6. DIRECTORYINFO (OOP)
            // =========================
            DirectoryInfo dirInfo = new DirectoryInfo(@"c:\practice\countries");

            dirInfo.Create();
            dirInfo.CreateSubdirectory("India");
            dirInfo.CreateSubdirectory("UK");
            dirInfo.CreateSubdirectory("USA");

            new FileInfo(Path.Combine(dirInfo.FullName, "capitals.txt")).Create().Close();
            new FileInfo(Path.Combine(dirInfo.FullName, "sports.txt")).Create().Close();
            new FileInfo(Path.Combine(dirInfo.FullName, "population.txt")).Create().Close();

            dirInfo.MoveTo(@"c:\practice\world");
            DirectoryInfo worldInfo = new DirectoryInfo(@"c:\practice\world");

            Console.WriteLine("\nDirectoryInfo Files:");
            foreach (FileInfo f in worldInfo.GetFiles())
                Console.WriteLine(f.FullName);

            Console.WriteLine("\nDirectoryInfo Sub folders:");
            foreach (DirectoryInfo d in worldInfo.GetDirectories())
                Console.WriteLine(d.FullName);

            worldInfo.Delete(true);
            Console.WriteLine("world folder deleted");

            dirInfo.Create();

            // ===========================
            // 7. DIRECTORYINFO PROPERTIES
            // ===========================

            if (dirInfo.Exists)
            {
                Console.WriteLine("Full Name: " + dirInfo.FullName);
                Console.WriteLine("Name: " + dirInfo.Name);
                Console.WriteLine("Directory Name: " + dirInfo.Parent);
                Console.WriteLine("Root: " + dirInfo.Root);           // drive
                Console.WriteLine("Creation date and time: " + dirInfo.CreationTime);
                Console.WriteLine("Last modification date and time: " + dirInfo.LastWriteTime);
                Console.WriteLine("Lat access date and time: " + dirInfo.LastAccessTime);
            }

            // ===========================
            // 8. DRIVEINFO PROPERTIES
            // ===========================
            DriveInfo driveInfo = new DriveInfo("c:");
            Console.WriteLine("Name: " + driveInfo.Name);
            Console.WriteLine("Drive Type: " + driveInfo.DriveType);
            Console.WriteLine("Volume Label: " + driveInfo.VolumeLabel);
            Console.WriteLine("Root Directory: " + driveInfo.RootDirectory);
            Console.WriteLine("Total Size: " + (driveInfo.TotalSize / 1024 / 1024 / 1024) + " gb"); // bytes - kb - mb - gb
            Console.WriteLine("Free space: " + (driveInfo.AvailableFreeSpace / 1024 / 1024 / 1024) + " gb");

            // ===========================
            // 9. FILESTREAM PROPERTIES
            // ===========================

            string filePath = @"c:\practice\dog.txt";
            FileInfo fileInfoDog = new FileInfo(filePath);

            //FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            //FileStream fileStream = File.Create(filePath);
            //FileStream fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write);
            //FileStream fileStream = File.OpenWrite(filePath);
            //FileStream fileStream = fileInfo.Create();
            //FileStream fileStream = fileInfo.Open(FileMode.Create, FileAccess.Write);
            FileStream fileStream = fileInfoDog.OpenWrite();

            //create content
            string content = "Dog is one of the domestic animal.";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(content);

            //Write
            fileStream.Write(bytes, 0, bytes.Length);
            //some work here
            string content2 = "other text here";
            byte[] bytes2 = System.Text.Encoding.ASCII.GetBytes(content2);
            fileStream.Write(bytes2, 0, bytes2.Length);

            fileStream.Close();
            Console.WriteLine("dog.txt created");

            //File reading
            //FileStream fileStream2 = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            //FileStream fileStream2 = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            //FileStream fileStream2 = File.OpenRead(filePath);
            //FileStream fileStream2 = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.Read);
            FileStream fileStream2 = fileInfoDog.OpenRead();

            //create empty byte[]
            byte[] bytes3 = new byte[fileStream2.Length];

            //Read
            fileStream2.Read(bytes3, 0, (int)fileStream2.Length);

            //convert byte[] to string
            string content3 = Encoding.ASCII.GetString(bytes3);
            Console.WriteLine("\nFile read. File content is:");
            Console.WriteLine(content3);
            fileStream2.Close();

            // ===============
            // 10. STREAMWRITER 
            // ===============

            string filePath6 = @"c:\practice\europe.txt";
            FileInfo fileInfo6 = new FileInfo(filePath6);
            //FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            //4 ways to create new object of StreamWriter
            //StreamWriter streamWriter = new StreamWriter(filePath);
            //StreamWriter streamWriter = new StreamWriter(fileStream);
            //StreamWriter streamWriter = fileInfo.AppendText();
            using (StreamWriter streamWriter = fileInfo6.CreateText())  // does close automatically
            {
                streamWriter.WriteLine("Russia has population about 145,934,000");
                streamWriter.WriteLine("Germany has population about 83,783,000");
                streamWriter.WriteLine("United Kingdom has population about 67,886,000");
                //streamWriter.Close(); //optional
            }

            // ===============
            // 11. STREAMREADER 
            // ===============
            //3 ways to create object of StreamReader:
            //StreamReader streamReader = new StreamReader(filePath);
            //StreamReader streamReader = fileInfo.OpenText()
            FileStream fileStream3 = new FileStream(filePath6, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream3))
            {
                Console.WriteLine("\nFile read. File content is:");

                //To read full file
                //string content_from_file = streamReader.ReadToEnd();
                //Console.WriteLine(content_from_file);

                //To read part-by-part (10 characters)
                char[] buffer = new char[10];
                int char_count;
                do
                {
                    char_count = streamReader.Read(buffer, 0, 10);
                    string s1 = new string(buffer);
                    Console.WriteLine(s1);
                } while (char_count > 0);
            }

            // ===============
            // 12. BINARYWRITER 
            // ===============

            short countryId = 1;
            string countryName = "France";
            long population = 65273511;
            string region = "Western Europe";
            string filePath4 = @"c:\practice\france.txt";
            FileStream fileStream4 = new FileStream(filePath4, FileMode.Create, FileAccess.Write);
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream4))
            {
                binaryWriter.Write(countryId); //0001
                binaryWriter.Write(countryName); //100 0100...
                binaryWriter.Write(population);
                binaryWriter.Write(region);
                //binaryWriter.Close(); 
            }
            Console.WriteLine("france.txt created");

            // ===============
            // 13. BINARYREADER
            // ===============

            //BinaryReader
            FileStream fileStream6 = new FileStream(filePath4, FileMode.Open, FileAccess.Read);
            using (BinaryReader binaryReader = new BinaryReader(fileStream6))
            {
                short countryId_from_file = binaryReader.ReadInt16();
                string countryName_from_file = binaryReader.ReadString();
                long population_from_file = binaryReader.ReadInt64();
                string region_from_file = binaryReader.ReadString();

                Console.WriteLine("Country ID: " + countryId_from_file);
                Console.WriteLine("Country Name: " + countryName_from_file);
                Console.WriteLine("Population: " + population_from_file);
                Console.WriteLine("Region: " + region_from_file);
            }

            // 14. BINARYFORMATTER - removed 


            // ==================
            // 15. JSON SERIALIZER
            // ==================
            //create object

            Customer customer = new Customer()
            {
                CustomerId = 1,
                CustomerName = "Nancy",
                Age = 20
            };

            string filePathJson = @"c:\practice\customer.txt";

            // Serialize
            string json = JsonSerializer.Serialize(customer);

            File.WriteAllText(filePathJson, json);

            Console.WriteLine(json);
            Console.WriteLine("Serialized");

            // Deserialize
            string jsonFromFile = File.ReadAllText(filePathJson);

            Customer customer_from_file =
                JsonSerializer.Deserialize<Customer>(jsonFromFile);

            Console.WriteLine(customer_from_file.CustomerId);
            Console.WriteLine(customer_from_file.CustomerName);
            Console.WriteLine(customer_from_file.Age);


            // =================
            // 16. XML SERIALIZER
            // =================

            var continents = new List<Continent>
                {
                    new Continent
                    {
                        ContinentName = "Africa",
                        Countries = new List<Country>
                        {
                            new Country { CountryID = 1, CountryName = "Sudan" },
                            new Country { CountryID = 2, CountryName = "Libya" },
                            new Country { CountryID = 3, CountryName = "South Africa" }
                        }
                    },
                    new Continent
                    {
                        ContinentName = "Asia",
                        Countries = new List<Country>
                        {
                            new Country { CountryID = 4, CountryName = "Russia" },
                            new Country { CountryID = 5, CountryName = "China" },
                            new Country { CountryID = 6, CountryName = "India" }
                        }
                    }
                };

            var xmlSerializer = new XmlSerializer(typeof(List<Continent>));
            string filePath8 = @"c:\practice\continents.xml";

            // Serialize
            using (var fs = new FileStream(filePath8, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, continents);
            }
            Console.WriteLine("XML created");

            // Deserialize
            List<Continent> continentsFromFile;
            using (var fs = new FileStream(filePath8, FileMode.Open))
            {
                continentsFromFile = (List<Continent>)xmlSerializer.Deserialize(fs);
            }

            Console.WriteLine("\nDeserialized:");
            foreach (var cont in continentsFromFile)
            {
                Console.WriteLine(cont.ContinentName);
                Console.WriteLine(string.Join(", ", cont.Countries.ConvertAll(c => c.CountryName)));
            }
            Console.ReadKey();
        }
    }
}