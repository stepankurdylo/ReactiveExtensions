namespace ReactiveExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;

    public static class Program
    {
        public static void Main()
        {
            KeyPresses().ToObservable().Buffer(3).Subscribe(keyPress =>
            {
                keyPress.Select(key => key.Key).ToList().ForEach(keyChar => Console.WriteLine($"\"{keyChar}\""));
            });
        }

        // Infinity Loop
        private static IEnumerable<ConsoleKeyInfo> KeyPresses()
        {
            for (;;)
            {
                var currentKey = Console.ReadKey(true);
                if (currentKey.Key == ConsoleKey.Enter)
                {
                    yield break;
                }
                else
                {
                    yield return currentKey;
                }
            }
        }
    }
}