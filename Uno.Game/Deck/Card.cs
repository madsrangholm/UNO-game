using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.DataTypes.Interfaces;
using Uno.DataTypes.Enums;

namespace Uno.Game.Deck
{
    public class Card : ICard
    {
        private ECardColor _color;
        private ECardValue _value;

        public Card()
        {
            _color = ECardColor.Red;
            _value = ECardValue.Zero;
        }

        public Card(ECardColor color, ECardValue value)
        {
            _color = color;
            _value = value;
        }

        public ECardValue GetValue
        {
            get { return _value; }
        }

        public ECardColor GetColor
        {
            get
            {
                return _color;
            }
            set
            {
                if (_value == ECardValue.ColorChange || _value == ECardValue.ColorChangePlusFour)
                    _color = value;
            }
        }

        public void Reset()
        {
            if (_value == ECardValue.ColorChange || _value == ECardValue.ColorChangePlusFour)
                _color = ECardColor.Undefined;
        }
    }
}
