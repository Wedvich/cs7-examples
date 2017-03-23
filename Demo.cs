using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cs7.Helpers;

namespace Cs7
{
    public static class Demo
    {
        public static void OutParameters()
        {
            // Out (expression) variables, type inference, discards

            var transform = new Transform();

            transform.GetScale(out _, out var y, out _);
        }

        public static void RefReturns()
        {
            // Ref returns, local variables, cannot reassign

            var map = new WorldMap();

            ref var tile = ref map.FindTileAt(2, 3);
            tile = new TreeTile();

            tile = map.FindTileAt(4, 1);
            tile = new LavaTile();
        }

        public static (char, int) GetMostCommonCharacter(string sentence = "the quick brown fox jumped over the lazy dog")
        {
            // Need System.ValueTuple
            // Custom names, return names
            // Deconstruction, type inference, deconstruction assignment, discard

            var occurences = new Dictionary<char, int>();
            foreach (var c in sentence.Replace(" ", ""))
            {
                occurences[c] = occurences.TryGetValue(c, out var count) ? count + 1 : 1;
            }

            var mostCommonOccurence = occurences.OrderByDescending(o => o.Value).First();
            return (mostCommonOccurence.Key, mostCommonOccurence.Value);
        }

        public static void Deconstruction()
        {
            // Deconstruct, extension method, assignment

            var message = new Message("Error", "Something went wrong for some message");

            var (subject, body) = message;
            Console.WriteLine($"{subject}: {body}");

            var exception = new Exception("Hello");
            var (exceptionMessage, hresult) = exception;
        }

        private static void Deconstruct(this Exception exception, out string message, out int hresult)
        {
            message = exception.Message;
            hresult = exception.HResult;
        }

        public static async Task AsyncReturnTypes()
        {
            // Sync result available, possible performance gains
            // More data, more convolution, Task still preferred

            IMessageProvider provider = new MessageProvider();
            var lastMessage = await provider.GetMostRecentMessage();

            provider = new DbMessageProvider();
            lastMessage = await provider.GetMostRecentMessage();
        }

        public static void PatternIs(object input)
        {
            // Is expression, pattern (expression) variables
            
            if (input is Hamster hamster)
            {
                hamster.Run();
            }
        }

        public static void PatternCase(Animal animal)
        {
            // Order matters, default last, when filters

            switch (animal)
            {
                case Duck duck:
                    duck.Quack();
                    break;

                case Hamster hamster when hamster.IsTired:
                    hamster.Rest();
                    break;

                case Hamster hamster:
                    hamster.Run();
                    break;

                case null:
                    break;

                default:
                    animal.Exist();
                    break;
            }
        }

        public static void Misc()
        {
            // Literal separators, binary numbers

            int million = 1_000_000;
            int billion = 1_000_000_000;

            int elite = 0x05_39;
            int twentyTwo = 0b0001_0110;
            
            // Local functions

            int multiply(int a, int b) => a * b;

            int lots = multiply(million, twentyTwo);
            int lotsAndLots = multiply(billion, elite);

            // Throw expressions

            int getMessageHash(Message message)
            {
                return message?.GetHashCode() ?? throw new ArgumentNullException(nameof(message));
            }

            try
            {
                getMessageHash(null);
            }
            catch (Exception)
            {
//              ¯\_(ツ)_/¯
            }

            // Expression bodied members

            new Inhabitant();
        }
    }
}
