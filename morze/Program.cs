
namespace morze
{
    internal class Program
    {

        static void Main()
        {
            char shortSignal;
            char longSignal;

            Console.WriteLine("Enter the character for the short signal: ");
            shortSignal = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.WriteLine("Enter the character for the long signal: ");
            longSignal = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (shortSignal == longSignal)
            {
                Console.WriteLine("Short and long signals must be different.");
                return;
            }

            MorseDecoder decoder = new MorseDecoder(shortSignal, longSignal);

            Console.WriteLine("Enter Morse code (separate letters with spaces, words with '/'):");
            string input = Console.ReadLine();

            string decodedMessage = decoder.Decode(input);
            Console.WriteLine("Decoded Message: " + decodedMessage);
        }
    }
}
