namespace Konvolucio.MCEL181123.Common
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;
    using System.Globalization;

    public static class Tools
    {


        /// <summary>
        /// Tulajdonság nevének megszerzése, még a tulajdonságban
        /// Típikus haszánlata:
        /// Minőségi szoftver estén használd!!!!
        /// <code> 
        /// set 
        /// { 
        ///     if (_year != value) 
        ///     {
        ///        _year = value; 
        ///        OnPropertyChanged(GetPropertyName(() => Year)); 
        ///     } 
        /// }</code>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public static String GetPropertyName<TValue>(Expression<Func<TValue>> propertyId)
        {
            return ((MemberExpression)propertyId.Body).Member.Name;
        }

        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }


        /// <summary>
        /// Az bájt tömb érték konvertálása string.
        /// </summary>
        /// <param name="byteArray">byte array</param>
        /// <param name="offset">az ofszettől kezdődően kezdődik a konvertálás</param>
        /// <returns>string pl.: (00 FF AA) </returns>
        public static string ConvertByteArrayLogString(byte[] byteArray)
        {
            string retval = string.Empty;

            for (int i = 0; i < +byteArray.Length; i++)
                retval += string.Format("{0:X2} ", byteArray[i]);

            if (byteArray.Length > 1)
                retval = retval.Remove(retval.Length - 1, 1);
            return (retval);
        }

        /// <summary>
        /// ByteArray To C-Style String.
        /// </summary>
        /// <param name="data">byte[] data</param>
        /// <returns>0x00,0x01</returns>
        public static string ConvertByteArrayToCStyleString(byte[] data)
        {
            string retval = string.Empty;
            for (int i = 0; i < data.Length; i++)
                retval += string.Format("0x{0:X2},", data[i]);
            //Az utolsó vessző törlése
            if (data.Length > 1)
                retval = retval.Remove(retval.Length - 1, 1);
            return retval;
        }

        /// <summary>
        /// ByteArray To C-Style String.
        /// </summary>
        /// <param name="data">byte[] data</param>
        /// <returns>0001</returns>
        public static string ConvertByteArrayToString(byte[] data)
        {
            string retval = string.Empty;
            for (int i = 0; i < data.Length; i++)
                retval += string.Format("{0:X2}", data[i]);
            if (data.Length > 1)
                retval = retval.Remove(retval.Length - 1, 1);
            return retval;
        }

        /// <summary>
        /// C-Style String To Byte Array
        /// </summary>
        /// <param name="cstyleByteArrayString">0x56,0x8D,0x85,0x5E</param>
        /// <returns>byte[]</returns>
        public static byte[] ConvertCStyleStringToByteArray(string cstyleByteArrayString)
        {
            if (cstyleByteArrayString.Length < 2)
                return new byte[0];
            string[] byteStrArray = cstyleByteArrayString.Split(',');
            byte[] data = new byte[byteStrArray.Length];

            for (int i = 0; i < byteStrArray.Length; i++)
            {
                byteStrArray[i] = byteStrArray[i].Trim();
                if (byteStrArray[i].Contains("0x"))
                    byteStrArray[i] = byteStrArray[i].Substring(2);

                if (byteStrArray[i].Length != 0)
                    data[i] = byte.Parse(byteStrArray[i], System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            return data;
        }


        /// <summary>
        /// Ez az időfomrátum a fájlnevekhez ajánlott
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateTimeToFileNameString(DateTime dt)
        {
            return dt.ToString("yyMMdd_HHmmss", System.Globalization.CultureInfo.InvariantCulture);
        }



    }
}
