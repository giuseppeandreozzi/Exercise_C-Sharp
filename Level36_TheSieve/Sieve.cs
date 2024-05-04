namespace Level36_TheSieve {
    internal class Sieve {
        Func<int, bool> function;

        public Sieve(Func<int, bool> function) {
            this.function = function;
        }

        public bool IsGood(int number) { 
            return function(number); 
        }
    }
}
