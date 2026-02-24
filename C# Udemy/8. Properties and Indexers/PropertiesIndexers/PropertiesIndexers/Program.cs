namespace PropertiesIndexers
{
    public class Program
    {
        // property - act  as a controlled layer,property does not allocate separate memnory like fields

        private int _age;
        private string _name;

        // creating properties
        public int Age
        {
            get { return _age; }  // readonly
            set { _age = value; } // writeonly
        }

        // auto implemented properties
        private int _height {  get; set; }
        private int _width { get; set; } = 10;  // auto implemented property intializer


    }
}
