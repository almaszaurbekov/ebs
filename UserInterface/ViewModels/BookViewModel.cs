using BusinessLogic.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserInterface.Mappings;

namespace UserInterface.ViewModels.Entities
{
    public class BookViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public int UserId { get; set; }
        public int Rate { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
        [Required]
        public bool InGoodCondition { get; set; } = true;
        [Required]
        public bool IsPainted { get; set; } = false;
        public List<CommentDto> Comments { get; set; }
        public bool RemoveImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserDto User { get; set; }
    }
}
