using System;

namespace CSharpTask1._2
{
    internal class Sportsman(string secondName, int birthYear, int[] competitionResults)
    {
        private readonly string _secondName = secondName;
        private readonly int _birthYear = birthYear;
        private readonly int[] _competitionResults = competitionResults;

        public int BirthYear => _birthYear;
        public string SecondName => _secondName;
        public int[] CompetitionResults => _competitionResults;

        public int this[int index] => _competitionResults[index];

        public override string ToString()
        {
            return $"{_secondName} ({_birthYear})";
        }
    }
}
