using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EanCode
    {
        public string CheckBarCode(string barCode, int eanType)
        {
            switch(eanType)
            {
                case 1:
                    return ExtractBarCode8(barCode);
                case 2:
                    return ExtractBarCode13( barCode);
                default:
                    throw new EanCodeTypeNotFound(eanType);
            }
        }
        private string ExtractBarCode8(string barCode)
        {
            Regex EAN8 = new Regex(@"^(\d{7}|\d{8})(\d{2}|\d{5})?$");
           
            Match m8 = EAN8.Match(barCode);

            if(m8.Success)
            {
                var ean = m8.Groups[1].ToString();
                return ean.PadLeft(8, '0');
            }
            else
            {
                throw new InvalidEanCodeException(barCode);
            }
        }

        private string ExtractBarCode13(string barCode)
        {
            Regex EAN13 = new Regex(@"^(\d{12}|\d{13})(\d{2}|\d{5})?$");

            Match m13 = EAN13.Match(barCode);
            if (m13.Success)
            {
                var ean = m13.Groups[1].ToString();
                return ean.PadLeft(13, '0');
            }
            else
            {
                throw new InvalidEanCodeException(barCode);
            }
        }
    }

    [Serializable]
    class InvalidEanCodeException : Exception
    {
        public InvalidEanCodeException(string eanCode)
            : base(String.Format($"Invalid Ean Code: {eanCode}"))
        {

        }
    }
    [Serializable]
    class EanCodeTypeNotFound : Exception
    {
        public EanCodeTypeNotFound(int eanType)
            : base(String.Format($"Ean Type not found: {eanType}"))
        {

        }
    }
}
