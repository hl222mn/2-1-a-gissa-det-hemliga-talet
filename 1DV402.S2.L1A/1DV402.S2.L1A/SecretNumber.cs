using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1DV402.S2.L1A
{
    public class SecretNumber
    {

        //fält
        private int _number = 1; // lagra hemliga talet- ska slumpas fram i intervallet 1-100
        private int _count = 0; //lagra antalet gissningar       
        public const int MaxNumberOfGuesses = 7;


        public void Initialize() //återställer ett objekt så att count=0 och number=nytt slumptal 
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _count = 0;
        }

        public bool MakeGuess(int number) //anrop = gissning (från out rad 43 i Program)
        {
            if (_count < MaxNumberOfGuesses) //kasta undantag vid (TEST) fler än max gissningar
            {
                if (number == _number)//rätt
                {
                    Console.WriteLine("Rätt gissat! Det hemliga numret var {0}!", _number);
                    _count = 0;
                    return true;
                }
                if (_count == MaxNumberOfGuesses) //testar antalet gissningar kvar
                {
                    Console.WriteLine("Fel! Du har inga gissningar kvar. Rätt siffra var {0}", _number);
                    return true;
                }
                if (number < 1 || number > 100)//testar intervallet
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (number < _number) //fel lågt
                {
                    Console.WriteLine("Fel! {0} är för lågt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - _count);
                    _count++;
                    return false;
                }
                if (number > _number) //fel högt
                {
                    Console.WriteLine("Fel! {0} är för högt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - _count);
                    _count++;
                    return false;
                }
            }
            
            throw new ApplicationException();
            //return false;
        }
    }
}
