//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkTwo
{
    using System;
    using System.Collections.Generic;
    
    public partial class fandv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Calories { get; set; }

        public fandv()
        {
        }
        public fandv(int id, string name, string type, string color, int calories)
        {
            Id = id;
            Name = name;
            Type = type;
            Color = color;
            Calories = calories;
        }
        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + Type + " " + Color + " " + Calories.ToString();
        }
    }
}
