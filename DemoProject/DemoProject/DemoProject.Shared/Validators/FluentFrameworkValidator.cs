using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DemoProject.Shared.Validators
{
	public class FluentFrameworkValidator : AbstractValidator<FluentFrameworkModel>
	{
		public FluentFrameworkValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Een naam graag");
			RuleFor(x => x.Name).Matches("^[a-zA-Z0-9]+$").WithMessage("Ik zoek letters en cijfers");

			RuleFor(x => x.Grade).NotEmpty().WithMessage("Een cijfer graag");
			RuleFor(x => x.Grade).InclusiveBetween(0, 50).WithMessage("Tussen 0 en 50 graag");

			//RuleFor(x => x.DateReleased).LessThan(x => DateTime.Now);
		}
	}
}
