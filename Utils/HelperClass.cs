namespace api_demo_e19.Utils
{
    public class HelperClass
    {
        /*
         Architecural pattern: These shape the overall structure and
         communication flow of an entire application or system.
        Ex: MVC, MVVM, MVP...
        */

        /*
        Design Pattern : These deal with the low-level, specific design of code 
        within a single component or module. 
        They provide established ways to write clean, 
        maintainable, and efficient object-oriented code.
        Ex: Singleton, Observer, Factory, Builder ....
        */

        // Singleton Pattern
        /*
        private HelperClass() { }

        public string myPro { get; set; } = "Value";

        public static HelperClass Shared => new ();

        public bool IsInvalidName(string name) => string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 50;
        */

        // Static Method
        public static bool IsInvalidName(string name) => string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 50;
    }
}
