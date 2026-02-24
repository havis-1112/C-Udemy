namespace Fields
{
    // 1.access modifiers
    public class Parent
    {
        private int _pri = 10;
        public int Pub = 20;
        protected int Prot = 30;
        internal int Inter = 40;
        protected internal int ProInt = 50;
        private protected int PrivProt = 60;

    }

    public class Child : Parent
    { 
     
        public void Check()
        {
            //_pri =0
            Pub = 30;
            Prot = 40;
            Inter = 50;
            ProInt = 60;
            PrivProt = 70;
        }
    }

    public class AnotherClass 
    {
        public void Check() 
        {
            Parent p = new Parent();
            //p._pri =0;
            p.Pub = 11;
            //p.Prot =12;
            p.Inter = 33;
            p.ProInt = 100;
            //p.PrivProc = 200;

        }
    }

    // 2. static,const,readonly,local constants
    public class Class1 
    {

        // instance fields -  heap,unique per object,via object
        public string Name;

        // static field - class memory,common to all objects,via class name
        public static int Age;

        // constant fields - fixed value,replaced by value in compile time so not stored in memory,initialized in declaration,via class name
        public const int Height = 50;

        //readonly fields - initilaized in declaration or constructor,runtime,via object name
        public readonly int Weight = 50; 

        // local constants - declared inside methods
        public void LocalConstants()
        {
            const double Pi = 3.14;
        }
    }


}
