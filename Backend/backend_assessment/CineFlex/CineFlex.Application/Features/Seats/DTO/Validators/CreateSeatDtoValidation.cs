namespace CineFlex.Application.Features.Seats.DTO.Validators;


 public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
    {
        public CreateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());
        }
    }
