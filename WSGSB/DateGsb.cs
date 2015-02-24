using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSGSB
{
    abstract class DateGsb
    {
        //date du jour au format DateTime(YYYY,MM,DD).
        static DateTime now = DateTime.Now;
        //tableau qui permet de trouver le mois suivant ou precedent en jouant avec index=>valeur
        static string[] arrayMonthPrec = new string[13] { "00", "12", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"};
        static string[] arrayMonthSuiv = new string[13] { "00", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" ,"12","01"};
        /// <summary>
        /// Retourne sous la forme d'une chaine de carractère de type "mm" le mois précedent la date entrée en paramètre
        /// </summary>
        /// <param name="date">DateTime.La date a entrer de type DateTime(YYYY,MM,DD). 
        /// Exemple: getMoisPrecedent(2015,02,02) renverra "01" </param>
        /// <returns>String. Retourne un mois au format "mm"</returns>
        public static string getMoisPrecedent(DateTime date)
        {           
            return arrayMonthPrec[date.Month];
        }

        /// <summary>
        /// Retourne sous la forme d'une chaine de carractère de type "mm" le mois précedent la date du jour
        /// </summary>
        /// <returns>String. Retourne un mois au format "mm"</returns>
        public static string getMoisPrecedent()
        {
            return getMoisPrecedent(now);
        }
        /// <summary>
        /// Retourne sous la forme d'une chaine de carractère de type "mm" le mois suivant la date du jour
        /// </summary>
        /// <param name="date">DateTime. La date a entrer de type DateTime(YYYY,MM,DD).
        /// Exemple: getMoisSuivant(2015,02,02) renverra "03"</param>
        /// <returns>String. Retourne un mois au format "mm"</returns>
        public static string getMoisSuivant(DateTime date)
        {
            return arrayMonthSuiv[date.Month];
        }
        /// <summary>
        /// Retourne sous la forme d'une chaine de carractère de type "mm" le mois suivant la date du jour
        /// </summary>
        /// <returns>String. Retourne un mois au format "mm"</returns>
        public static string getMoisSuivant()
        {
            return getMoisSuivant(now);
        }
        /// <summary>
        /// Retourne vrai si la date entrée en paramètre est comprise entre le dayA etB inclus
        /// exemple: entre(1,10,(2015,02,08)) retourne vrai
        /// </summary>
        /// <param name="dayA">int: jour bas </param>
        /// <param name="dayB">int: jour haut</param>
        /// <param name="date">bool</param>
        /// <returns></returns>
        public static bool entre(int dayA, int dayB,DateTime date)
        {
            if (dayA < dayB && dayA > 0 && dayB <= 31)
            {
                int day = date.Day;
                return (day >= dayA && day <= dayB);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Retourne vrai si la date du jour actuel est comprise entre le dayA etB inclus
        /// </summary>
        /// <param name="dayA">int: jour bas </param>
        /// <param name="dayB">int: jour haut</param>
        /// <param name="date">bool</param>
        public static bool entre(int dayA, int dayB)
        {
            return entre(dayA, dayB,now); 
        }

        /// <summary>
        /// Retourne l'année et le mois precedent de la date entrée en parametre au format YYYYMM
        /// Exemple getAnnMoisPrecedent(2015,1,1) retourne "201401"
        /// </summary>
        /// <param name="date">DateTime </param>
        /// <returns>string au format "YYYYMM"</returns>
        public static string getAnnMoisPrecedent(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            if (month == 1)
            {
                year--;
            }
            string moisPrec = Convert.ToString(year) + getMoisPrecedent(date);
            return moisPrec;
        }
        /// <summary>
        ///  Retourne l'année et le mois precedent de la date actuelle au format YYYYMM
        /// </summary>
        /// <returns>string au format "YYYYMM"</returns>
        public static string getAnnMoisPrecedent()
        {
            return(getAnnMoisPrecedent(now));
        }

    }
}
