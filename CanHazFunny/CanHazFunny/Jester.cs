using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    sealed internal class Jester
    {
        private IOutput Output { get; set; }
        private IJokeService JokeService { get; set; }
        public Jester(IOutput output, IJokeService jokeService)
        {
            ArgumentNullException.ThrowIfNull(output);
            ArgumentNullException.ThrowIfNull(jokeService);
            Output = output;
            JokeService = jokeService;
        }

        public void TellJoke()
        {
            bool isChuckNorris = false;
            string joke;
            do {
                joke = JokeService.GetJoke();
                isChuckNorris = joke.Contains("Chuck") || joke.Contains("Norris");
            } while (isChuckNorris || joke is null);
            Output.ShowOutput(joke);
        }
    }
}
