using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    sealed internal class Jester
    {
        public IOutput Output { get; set; }
        public JokeService JokeService { get; set; }
        public Jester(IOutput output, JokeService jokeService)
        {
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
