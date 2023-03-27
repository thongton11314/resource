using System;
using System.Collections.Generic;
using System.Linq;
using CardGame.Properties;

namespace CardGame.Service
{
    public class CardGameService
    {
        private List<Card> _deck;
        private Random _random;

        public CardGameService()
        {
            _random = new Random();
            Restart();
        }

        private void InitializeDeck()
        {
            _deck = new List<Card>();

            // For Suit
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {

                // For Face
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    _deck.Add(new Card { m_suit = suit, m_face = face });
                }
            }
        }

        public object DrawCard()
        {
            // Empty desk
            if (_deck.Count == 0)
            {
                return new { success = false };
            }
            
            // Non-empty desk
            int index = _random.Next(_deck.Count);

            // Get the top card
            Card drawnCard = _deck[index];

            // Remove from the Desk
            _deck.RemoveAt(index);

            // Return JSON {} Objet
            return new { cardName = drawnCard.ToString(), remaining = _deck.Count };
        }

        public object Shuffle()
        {
            _deck = _deck.OrderBy(card => _random.Next()).ToList();
            return new { success = true, remaining = _deck.Count };
        }

        public object Restart()
        {
            InitializeDeck();
            Shuffle();
            return new { success = true, remaining = _deck.Count };
        }

        public object ShowCards()
        {
            return new { count = _deck.Count, remainingCards = _deck.Select(card => card.ToString()).ToList() };
        }

        public object PutCard(Card card)
        {
            if (_deck.Any(c => c.m_suit == card.m_suit && c.m_face == card.m_face))
            {
                return new { success = false, remaining = _deck.Count };
            }
            _deck.Add(card);
            return new { success = true, remaining = _deck.Count };
        }
    }
}