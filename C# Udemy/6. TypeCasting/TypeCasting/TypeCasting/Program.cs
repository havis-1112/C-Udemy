namespace TypeCasting
{
    public class Program
    {
        public void Casting()
        {
            // 1. implicit casting (low to high)
            int a = 10;
            double b = a;

            // 2. explicit casting
            double c = 3.4;
            int d = (int)c;

            // 3. parse (string to numerical)
            string str = "123";
            int e  = int.Parse(str);

            // 4. tryparse (string to numerical with error handling)
            string str2 = "456";
            int f;
            bool sucess = int.TryParse(str2, out f);

            // 5. conversion methods - primitive to any primitive types and also to datetime,base64
            string str3 = "543";
            int g = Convert.ToInt32(str3);

            string status = "true";
            bool h = Convert.ToBoolean(status);

        }
    }
}
