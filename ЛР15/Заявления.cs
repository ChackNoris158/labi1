//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ЛР15
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заявления
    {
        public int Код_заявления { get; set; }
        public int Код_абитуриента { get; set; }
        public int Код_специальности { get; set; }
        public string Статус { get; set; }
    
        public virtual Абитуриенты Абитуриенты { get; set; }
        public virtual Абитуриенты Абитуриенты1 { get; set; }
        public virtual Специальности Специальности { get; set; }
        public virtual Специальности Специальности1 { get; set; }
    }
}
