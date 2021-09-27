using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Commands
{
    public class CreateArticleCommand : IRequest<ResultWrapper<CreateArticleOutput>>
    {
        public string FireBaseId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Image { get; set; }        
        public bool Enabled { get; set; }
        public List<int> Sports { get; set; }
    }
}