using System.Text.RegularExpressions;

namespace Fashion_API.Service
{
    public class Slugify
    {
        // "/[-'`~!@#$%^&*()_|+=?;:'",.<>\{\}\[\]\\\/]/gi"
        //ÀÁÂÃÈÉÊẾÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêếìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỂưăạảấầẩẫậắằẳẵặẹẻẽềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ
        //"àáãảạăằắẳẵặâầấẩẫậèéẻẽẹêềếểễệđùúủũụưừứửữựòóỏõọôồốổỗộơờớởỡợìíỉĩịäëïîöüûñçýỳỹỵỷ";
        public static string[] vietnamese_alphabet = new string[] {
          "aeduoiy",
          "àáãảạăằắẳẵặâầấẩẫậ",
          "èéẻẽẹêềếểễệ",
          "đ",
          "ùúủũụưừứửữự",
          "òóỏõọôồốổỗộơờớởỡợ",
          "ìíỉĩị",
          "ýỳỹỵỷ"
        }; 
        public static string VietnamSigns(string pharse)
        {
            //convert to lower cass
            pharse = pharse.ToLower();
            //Check all special characters from the string.
            bool isAccent = Regex.IsMatch(pharse, @"[àáãảạăằắẳẵặâầấẩẫậèéẻẽẹêềếểễệđùúủũụưừứửữựòóỏõọôồốổỗộơờớởỡợìíỉĩịýỳỹỵỷ]");
            if (!isAccent) return pharse;

            for(int i = 1; i < vietnamese_alphabet.Length; i++)
            {
                for(int j = 0; j < vietnamese_alphabet[i].Length; j++)
                {
                    pharse = pharse.Replace(vietnamese_alphabet[i][j], vietnamese_alphabet[0][i-1]);
                }
            }           
            pharse = pharse.Replace(" ", "-");
            return pharse;
        }
    }
}
