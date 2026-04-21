using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum BlogPostSort
    {
        CreatedAtAsc = 1,   // الأحدث الأول — الأهم
        CreatedAtDesc = 2,   // الأحدث الأول — الأهم
        TitleAsc = 3,       // أبجدي
        TitleDesc = 4,       // أبجدي
        UpdatedAtAsc = 5 ,   // آخر تعديل
        UpdatedAtDSec = 6    // آخر تعديل
    }
}
