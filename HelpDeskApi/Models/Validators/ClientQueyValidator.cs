using FluentValidation;
using HelpDeskApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Models.Validators
{
    public class ClientQueyValidator : AbstractValidator<ClientQuery>
    {
        private int [] allowedPageSizes = new[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(Client.Name), nameof(Client.ServiceMenager), nameof(Client.Contrac) ,};


      
public ClientQueyValidator()
        {
            RuleFor(c => c.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(c => c.PageSize).Custom((value,context)=>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("Ilość elementów", $"Ilość elementów morze być [{string.Join(",", allowedPageSizes)}]");
                }
            
            });

            RuleFor(c => c.SortBy).Must(value=> string.IsNullOrEmpty(value)|| allowedSortByColumnNames.Contains(value))
                .WithMessage($"Jest to okno opcjonalne ale musie się mieścić w[{string.Join(",",allowedSortByColumnNames)  }] ");



        }
    }
}
