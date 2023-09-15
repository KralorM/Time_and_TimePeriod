using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_TimePeriod
{
   public struct Time_period_1
    {   //Zmienne
        private readonly byte hours;
        private readonly byte minutes;
        private readonly long seconds;
        
        /// <summary>
        /// Properties zwracające kolejno Godziny,Minuty,Sekundy
        /// </summary>
        public byte Hours
        {
            get
            {
                return hours;
            }


        }

        public byte Minutes
        {
            get
            {
                return minutes;
            }


        }

        public byte Seconds
        {
            get
            {
                return (byte)seconds;
            }



        }

        /// <summary>
        /// Konstruktory ,służące do tworzenia obiektów(przedziałów czasowych), mamy trzy typy taki konsrutkorów, I przyjmuje godziny,minuty,sekundy
        /// II godzinu i minuty a III same godziny i IV który przyjmuje input w postaci stringu i przekształca go na widoczny czas
        /// </summary>
        /// <param name="hours">Godziny</param>
        /// <param name="minutes">Minuty</param>
        /// <param name="seconds">Sekundy</param>
        /// <exception cref="ArgumentException"></exception>
        public Time_period_1(byte hours, byte minutes, byte seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;

            if (hours < 0 || minutes < 0 || seconds < 0)
            {
                throw new ArgumentException();
            }


        }

        public Time_period_1(byte hours, byte minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = 00;

            if (hours < 0 || minutes < 0)
            {
                throw new ArgumentException();
            }
        }

        public Time_period_1(byte hours)
        {
            this.hours = hours;
            this.minutes = 00;
            this.seconds = 00;
            if (hours < 0 || hours > 23)
            {
                throw new ArgumentException();
            }
        }

        public Time_period_1(string Time_p)
        {
            string[] Timeinstring = Time_p.Split(":");
            byte[] time = Array.ConvertAll(Timeinstring, byte.Parse);
            this.hours = (byte)time[0];
            this.minutes = (byte)time[1];
            this.seconds = (byte)time[2];

            if (hours < 0 || minutes < 0 || seconds < 0 || hours > 23 || minutes > 59 || seconds > 59)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Nadpisana metoda ToString()
        /// </summary>
        /// <returns>Zwraca przedział czasowy w formie tekstowej w formacie Godziny:Minuty:Sekundy</returns>
        public override string ToString()
        {
            return hours + ":" + minutes + ":" + seconds;
        }

        //IEquals and IComparable
        /// <summary>
        /// Implementacja Interfejsu IEquatable i IComparable
        /// </summary>
        /// <param name="other">Nasz przedział czasowy który będzie porównywany</param>
        /// <returns>Zwarac nam prawdę jeżeli dwa przedziały czasowe są sobie równy i fałszy gdy nie są</returns>
        public bool Equals(Time_period_1 other)
        {
            if (this.hours == other.hours && this.minutes == other.minutes && this.seconds == other.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null || obj is not Time_period_1)
            {
                return false;
            }
            return Equals((Time_period_1)obj);
        }

        /// <summary>
        /// Nadpisanie Metody GetHashCode()
        /// </summary>
        /// <returns>Zwaraca nam unikalny numer naszego obiektu</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Implementacja IComparable
        /// </summary>
        /// <param name="other">przedział czasowy który porównujemy</param>
        /// <returns>zwraca -1 gdy nasz obiekt jest mniejszy, 0 gdy obiekty są równe lub 1 gdy nasz obiekt jest większy</returns>
        public int CompareTo(Time_period_1 other)
        {
            if (this.Hours > other.Hours)
            {
                return 1;
            }
            else if (this.Hours < other.Hours)
            {
                return -1;
            }
            else if (this.Hours == other.Hours)
            {
                if (this.Minutes > other.Minutes)
                {
                    return 1;
                }
                else if (this.Minutes < other.Minutes)
                {
                    return -1;
                }
                else if (this.Minutes == other.Minutes)
                {
                    if (this.Seconds > other.Seconds)
                    {
                        return 1;
                    }
                    else if (this.Seconds < other.Seconds)
                    {
                        return -1;
                    }

                }
            }
            return 0;
        }


        //Operatory
        /// <summary>
        /// Przeciążanie operatorów
        /// </summary>
        /// <param name="t1">Pierwszy przedział czasowy</param>
        /// <param name="t2">Drugi przedział czasowy</param>
        /// <returns>Zwraca nam -1 gdy nasz obiekt jest mniejszy, zwraca 1 gdy nasz obiekt jest większy, zwraca wartość metody Equals gdy
        /// nasze obiekty są równe i zwraca wartość wyrażenie !(t1==t2) gdy nasze obiekty nie są równe</returns>
        public static bool operator <(Time_period_1 t1, Time_period_1 t2)
        {
           return t1.CompareTo(t2) == -1;
        }

        public static bool operator >(Time_period_1 t1, Time_period_1 t2)
        {
            return t1.CompareTo(t2) == 1;
        }

        public static bool operator ==(Time_period_1 t1, Time_period_1 t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Time_period_1 t1, Time_period_1 t2)
        {
            return !(t1 == t2);
        }

        public static bool operator <=(Time_period_1 t1, Time_period_1 t2)
        {
            return t1.CompareTo(t2) <= 0;
        }

        public static bool operator >=(Time_period_1 t1, Time_period_1 t2)
        {
            return t1.CompareTo(t2) >= 0;
        }

        /// <summary>
        /// Przeciążenia operatorów i Metoda Plus i Minus
        /// </summary>
        /// <param name="t1">Pierwszy przedział czasowy</param>
        /// <param name="t2">Drugi przedział czasowy</param>
        /// <returns>Zwraca nam obiekt typu Time_period_1(reprezentujący nasze przedziały czasowe) którego wartość będzie równa wartości wyniku dodania 
        /// dwóch przedziałów czasowych, w przypadku Metody Minus schemat działania jesy odwrotny</returns>
        public static Time_period_1 operator +(Time_period_1 t1, Time_period_1 t2)
        {
            long sum_min = t1.minutes + t2.minutes;
            long sum_hours = t1.hours + t2.hours;
            long sum_seconds = t1.seconds + t2.seconds;

            return new Time_period_1((byte)sum_hours, (byte)sum_min, (byte)sum_seconds);

        }

        public static Time_period_1 Plus(Time_period_1 t1, Time_period_1 t2)
        {
            long sum_min = t1.minutes + t2.minutes;
            long sum_hours = t1.hours + t2.hours;
            long sum_seconds = t1.seconds + t2.seconds;

            return new Time_period_1((byte)sum_hours, (byte)sum_min, (byte)sum_seconds);
        }

        public static Time_period_1 Minus(Time_period_1 t1, Time_period_1 t2)
        {   
            long sub_hours = t1.hours - t2.hours;
            long sub_min = t1.minutes - t2.minutes;
            long sub_sec = t1.seconds - t2.seconds;

            return new Time_period_1((byte)sub_hours,(byte)sub_min,(byte)sub_sec);

            
        }

       
    }
}
