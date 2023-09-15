using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Time_TimePeriod
{
   public struct Time: IEquatable<Time>,IComparable<Time>
    {
        //Zmienne
        private byte hours;
        private byte minutes;
        private long seconds;


        //Properties
        /// <summary>
        /// Properties zwracające kolejno godziny, minuty i sekudny
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


        //Constructors
        /// <summary>
        /// Konstruktory Klasy Time, przyjmuje on godziny, minuty, sekundy w typie byte i sprawdza czy
        /// czas aby przypadkiem nie jest ujemny.Mamy stowrzone 3 typy konstruktorów, które kolejno przyjmują albo same
        /// godziny i minuty lub same godziny.
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <exception cref="ArgumentException"></exception>
        public Time(byte hours, byte minutes, byte seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;

            if(hours < 0 || minutes <0 || seconds < 0)
            {
                throw new ArgumentException();
            }


        }

        public Time(byte hours,byte minutes)
        {
            this.hours=hours;
            this.minutes=minutes;
            this.seconds = 00;

            if (hours < 0 || minutes < 0)
            {
                throw new ArgumentException();
            }
        }


        public Time(byte hours)
        {
            this.hours = hours;
            this.minutes = 00;
            this.seconds = 00;
            if (hours < 0 || hours > 23)
            {
                throw new ArgumentException();
            }
        }

        public Time(string Time_p)
        {
            string[] Timeinstring = Time_p.Split(":");
            byte[] time = Array.ConvertAll(Timeinstring,byte.Parse);
            this.hours = time[0];
            this.minutes = time[1];
            this.seconds = time[2];

            if (hours < 0 || minutes < 0 || seconds < 0 || hours > 23 || minutes > 59 || seconds > 59)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Nadpisana Metoda ToString() zwracająca napis godziny w formacie Godziny:Minuty:Sekundy
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Hours + ":" + Minutes + ":" + Seconds;
        }

        //IEquals and IComparable 
        /// <summary>
        /// Implementacja Interfejsów IEquals i IComparable
        /// </summary>
        /// <param name="other">Porównywany obiekt</param>
        /// <returns>Zwaraca Prawdę gdy obiekty są równe lub Fałsz gdy nie są</returns>
        public bool Equals(Time other)
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
            if (obj is null || obj is not Time)
            {
                return false;
            }
            return Equals((Time)obj);
        }

        /// <summary>
        /// Metoda GetHashCode()
        /// </summary>
        /// <returns>Zwraca unikalny numer naszego obiektu</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Time other)
        {

            if (this.Hours > other.Hours)
            {
                return 1;
            }
            else if(this.Hours < other.Hours)
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
                    if(this.Seconds > other.Seconds)
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
        /// Seria operatrów służąca do porównywania dwóch punktów czasowych przy wykorzystaniu IComparable oraz IEquatable
        /// </summary>
        /// <param name="t1">pierwszy punkt czasowy</param>
        /// <param name="t2">drugi punkt czasowy</param>
        /// <returns>zwraca -1 gdy nasz obiekt jest mniejszy, 1 gdy nasz obiekt jest większy, gdy obiekty są równe zwraca wynik Metody Equals lub
        /// w przyapdku nierówności wynik wyrażenia</returns>
        public static bool operator <(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == -1;
        }

        public static bool operator >(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == 1;
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) <= 0;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) >= 0;
        }

        //Plus and Minus Methods
        /// <summary>
        /// Metoda Plus
        /// </summary>
        /// <param name="t2">przedział czasowy który chcemy dodać</param>
        /// <returns>Zwraca nam nasz punkt czasowy przesunięty o wartość przedziału który dodajemy</returns>
        public Time Plus(Time_period_1 t2)
        {
            return this + t2;
        }
        /// <summary>
        /// Minus Method
        /// </summary>
        /// <param name="time_Period_1">przedział czasowy który chcemy odjąć</param>
        /// <returns>Zwraca nam nasz punkt czasowy przesunięty o wartość przedziału który odejmujemy</returns>
        public Time Minus(Time_period_1 time_Period_1)
        {   
            long sum_Time_period = ((this.hours*3600)) + ((this.minutes*60)) + (this.seconds);
            long sum_Time_period_1 = ((time_Period_1.Hours * 3600)) + ((time_Period_1.Minutes * 60)) + (time_Period_1.Seconds);
            long sum_time = sum_Time_period - sum_Time_period_1;

            while ((sum_time / 3600) % 24 < 0)
            {
                sum_time += 24 * 3600;
            }
            while ((sum_time / 60) % 60 < 0)
            {

                sum_time += 86400;
            }
            while (sum_time % 60 < 0)
            {

                sum_time += 86400;

            }

            return new Time((byte)((sum_time / 3600) % 24), (byte)((sum_time / 60) % 60), (byte)(sum_time % 60));
           
        }

        public static Time Plus(Time t1, Time_period_1 time_Period_1)
        {
            return t1 + time_Period_1;
        }

        public static Time Minus(Time t1,Time_period_1 time_Period_1)
        {
            long sub_s = t1.Seconds - time_Period_1.Seconds;
            long sub_h = ((t1.Hours)*3600) - ((time_Period_1 .Hours)*3600);
            long sub_m = ((t1.Minutes)*60) - ((time_Period_1 .Minutes)*60);

            return new Time((byte)((sub_h/3600)%24),(byte)((sub_m/60)%60),(byte)((sub_s%60)));
        }

        /// <summary>
        /// Przeciążenia operatorów + i -
        /// </summary>
        /// <param name="t1">punkt czasowy</param>
        /// <param name="time_Period_1">przedział czasowy</param>
        /// <returns>Zwraca nam godzine(nasz punkt czasowy) po przesunieciu go o wartość przedziału czasowego</returns>
        public static Time operator+(Time t1, Time_period_1 time_Period_1)
        {
            long sum = ((t1.Hours * 3600) + (t1.minutes * 60) + t1.seconds + (time_Period_1.Hours*3600) + (time_Period_1.Minutes * 60) + time_Period_1.Seconds);
            return new Time((byte)((sum/3600) % 24), (byte)((sum / 60) % 60), (byte)(sum % 60));
        }

        public static Time operator -(Time t1, Time_period_1 time_Period_1)
        {
            long sum = ((t1.Hours * 3600) + (t1.minutes * 60) + t1.seconds - (time_Period_1.Hours * 3600) + (time_Period_1.Minutes * 60) + time_Period_1.Seconds);
            return new Time((byte)((sum / 3600) % 24), (byte)((sum / 60) % 60), (byte)(sum % 60));
        }
    }
}
