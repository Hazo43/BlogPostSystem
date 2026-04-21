using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.BlogPostModule
{
    public record BlogPostRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int AuthorId { get; set; } //  Token هنبعتو مع ال
        public string Status { get; set; } = string.Empty;
        public List<int> TagIds { get; set; } = new();

    }
}
