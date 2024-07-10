namespace SoldierFit.Core.Profiles
{
    using AutoMapper;
    using SoldierFit.Core.Models.Athlete;
    using SoldierFit.Core.Models.Workout;
    using SoldierFit.Infrastructure.Data.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Workout, WorkoutIndexViewModel>()
                .ReverseMap();

            this.CreateMap<Workout, CreateWorkoutViewModel>()
                .ReverseMap();

            this.CreateMap<Workout, WorkoutDetailsViewModel>()
                .ForMember(
                    w => w.Athlete,
                    config => config
                    .MapFrom(src => new AthleteIndexViewModel
                    {
                        FirstName = src.Athlete.FirstName,
                        MiddleName = src.Athlete.MiddleName,
                        LastName = src.Athlete.LastName,
                        PhoneNumber = src.Athlete.PhoneNumber
                    }))
                .ReverseMap();
        }
    }
}
