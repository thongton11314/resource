namespace CardGame.Properties
{
    public enum Suit
    {
        Clubs,
        Hearts,
        Spades,
        Diamonds
    }

    public enum Face
    {
        Ace,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit m_suit { get; set; }
        public Face m_face { get; set; }

        public override string ToString()
        {
            return $"The {m_face} of {m_suit}";
        }
    }
}
