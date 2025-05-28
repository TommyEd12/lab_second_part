using System;

namespace Lab
{
    class Money
    {
        private uint _rubles;
        private byte _kopeks;

        public uint Rubles
        {
            get => _rubles;
            set => _rubles = value;
        }

        public byte Kopeks
        {
            get => _kopeks;
            set
            {
                if (value > 99)
                    throw new ArgumentOutOfRangeException(nameof(Kopeks), "Копеек должно быть от 0 до 99");
                _kopeks = value;
            }
        }

        public Money(uint _rubles = 0, byte _kopeks = 0)
        {
            if (_kopeks > 99)
                throw new ArgumentOutOfRangeException(nameof(_kopeks), "Копеек должно быть от 0 до 99");

            this._rubles = _rubles;
            this._kopeks = _kopeks;
        }

        public Money AddKopeks(uint addKopeks)
        {
            ulong totalKopeks = (ulong)_rubles * 100 + _kopeks + addKopeks;
            uint newRubles = (uint)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);
            return new Money(newRubles, newKopeks);
        }

        public override string ToString()
        {
            return $"{_rubles} руб. {_kopeks:D2} коп.";
        }

        public static Money operator ++(Money m)
        {
            return m.AddKopeks(1);
        }

        public static Money operator --(Money m)
        {
            return m - 1;
        }

        public static explicit operator uint(Money m)
        {
            return m._rubles;
        }

        public static implicit operator double(Money m)
        {
            return (double)(m._rubles * 100 + m._kopeks) / 100;
        }

        public static Money operator +(Money m, uint addKopeks)
        {
            return m.AddKopeks(addKopeks);
        }

        public static Money operator -(Money m, uint subtractKopeks)
        {
            ulong totalKopeks = (ulong)m._rubles * 100 + m._kopeks - subtractKopeks;
            if (totalKopeks < 0)
                throw new InvalidOperationException("Результат вычитания не может быть отрицательным");
            uint rubles = (uint)(totalKopeks / 100);
            byte kopeks = (byte)(totalKopeks % 100);
            return new Money(rubles, kopeks);
        }

    }
}