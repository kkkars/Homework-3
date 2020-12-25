namespace Task_1._4
{
    class BracketWithIndex
    {
        public int Index { get; private set; }
        public char Bracket { get; private set; }

        public BracketWithIndex(int index, char bracket)
        {
            if (index >= 0)
                Index = index;
            Bracket = bracket;
        }
    }
}
