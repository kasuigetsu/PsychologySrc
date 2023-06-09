﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace PsychologyApp.WebApi.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class CodeBusket
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int userId { get; set; }
        [Column("user_role")]
        public int userRole { get; set; }
        [Column("code")]
        public string Code { get; set; }      
    }
}
