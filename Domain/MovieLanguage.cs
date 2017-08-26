using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Domain
{
    //This is a merge of the Language table and the MovieLanguage table--purely domain modeling and not completely reflective of the data model
    public class MovieLanguage
    {
        public string Code { get; set; }

        [Key]
        public int LanguageId { get; set; }

        public string Name { get { return string.IsNullOrEmpty(Code) ? string.Empty : CultureInfo.GetCultureInfo(Code).DisplayName; } }

        public bool OriginalLanguage { get; set; }
    }
}