using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     * Celem zadania jest napisanie funkcji sprawdzającej, czy podany tekst jest kodem kreskowym EAN-13
lub EAN-8.
Na wejściu funkcji są dwa parametry:
- wejściowy kod kreskowy: parametr tekstowy
- rodzaj kodu kreskowego - parametr numeryczny: 1 dla EAN-8, 2 dla EAN-13.
Niektóre towary (np. czasopisma) mają dodatkowe kody (tzw. add-on'y) - należy mieć na uwadze, że
skaner może dokleić je bezpośrednio do właściwego kodu kreskowego (np. dla towaru o kodzie
"6920702707721" oraz add-on’ie "12" na wejściu możliwy jest ciąg "692070270772112"). Należy
założyć, że add-on'y mogą występować zarówno dla kodów EAN-8 jaki i EAN-13.
Należy mieć na uwadze, że niektóre skanery kodów kreskowych mogą wycinać z kodu kreskowego
pierwsze wiodące zero (np. zamiast kodu "0075678164125" przesyłają "075678164125").
Na wyjściu funkcja powinna zwracać prawidłowy kod kreskowy (o długości 8 lub 13 znaków) bez
ewentualnego add-on'u.
Ewentualne błędy w danych wejściowych powinny być sygnalizowane wyjątkami.
    */
    class EanCode
    {
        public string CheckBarCode(string barCode, int eanType)
        {
            string vaildBarCode = null;

            int barCodeLenght = barCode.Length;
            switch(eanType)
            {
                case 1:
                    vaildBarCode = CheckIfBarCode8IsValid(barCodeLenght, barCode);
                    break;
                case 2:
                    vaildBarCode = CheckIfBarCode13IsValid(barCodeLenght, barCode);
                    break;
                default:
                    throw new Exception(String.Format("Unknown ean type: {0}", eanType));
            }
            return vaildBarCode;
        }
        public string ChangeEan8Code(string validEanCode, int eanLenght)
        {
            string correctEan = "";
            if(eanLenght == 9 || eanLenght == 10)
            {
                correctEan = RemoveCharsFromString(validEanCode, 2);

            } else if (eanLenght == 12 || eanLenght == 13)
            {
                correctEan = RemoveCharsFromString(validEanCode, 5);
            }
            return correctEan;
        }
        public string ChangeEan13Code(string validEanCode, int eanLenght)
        {
            string correctEan = "";
            if (eanLenght == 14 || eanLenght == 15)
            {
                correctEan = RemoveCharsFromString(validEanCode, 2);

            }
            else if (eanLenght == 17 || eanLenght == 18)
            {
                correctEan = RemoveCharsFromString(validEanCode, 5);
            }
            return correctEan;
        }
        private string RemoveCharsFromString(string eanCode, int numberCharToRemove)
        {
            return eanCode.Substring(0, eanCode.Length - numberCharToRemove);
        }
        public string CheckIfBarCode8IsValid(int barCodeLenght, string barCode)
        {
            Regex EAN8 = new Regex(@"\b(?:\d{7,10}|\d{12,13})\b");
           
            Match m8 = EAN8.Match(barCode);

            if(m8.Success)
            {
                barCode = ChangeEan8Code(barCode, barCodeLenght);
            }
            else
            {
                throw new Exception(String.Format("EAN Code incorrect: {0}", barCode));
            }

            return barCode;
        }

        public string CheckIfBarCode13IsValid(int barCodeLenght, string barCode)
        {
            Regex EAN8 = new Regex(@"\b(?:\d{12,15}|\d{17,18})\b");

            Match m8 = EAN8.Match(barCode);
            if (m8.Success)
            {
                barCode = ChangeEan8Code(barCode, barCodeLenght);
            }
            else
            {
                throw new Exception(String.Format("EAN Code incorrect: {0}", barCode));
            }

            return barCode;
        }
    }
}
