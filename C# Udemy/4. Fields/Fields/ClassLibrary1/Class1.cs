using Fields;

namespace ClassLibrary1
{
    public class ChildClass : Parent
    {
        public void Check()
        {
            Pub = 12;
            Prot = 13;
            ProInt = 14;

            //_pri = 15;
            //Inter = 16;
            //PriProt = 17;
        }
    }

    public class AnotherClass 
    {
        public void Check() 
        { 
          Parent p = new Parent();       
            p.Pub = 12;
        }
    }

}
