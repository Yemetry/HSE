using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class User
    {
        public User()
        {
            SaveBuilds = new HashSet<SaveBuild>();
        }
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия пользователя")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Id пользователя")]
        public int UserId { get; set; }

        public virtual ICollection<SaveBuild> SaveBuilds { get; set; }
    }
}
