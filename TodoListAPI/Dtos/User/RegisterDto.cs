﻿using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Dtos.User
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
