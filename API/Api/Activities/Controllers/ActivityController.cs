using API.Api.Activities.Resources;
using ApplicationShared.Activities.Commands;
using ApplicationShared.Activities.Queries;
using Core.CommandManager;
using Core.QueryManager;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.InputModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Activities.Controllers
{
    [Route(ActivityRoutes._baseRoute)]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IQueryManager _queryManager;
        private readonly ICommandManager _commandManager;

        public ActivityController(IQueryManager queryManager, ICommandManager commandManager)
        {
            _queryManager = queryManager;
            _commandManager = commandManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityResponse>>> GetAll()
        {
            List<Activity> activities = await _queryManager.Send(new GetActivitiesQuery());
            return MapToResponse(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityResponse>> Get(string id)
        {
            Activity activity = await _queryManager.Send(new GetActivityByGuidQuery(id));
            return MapToResponse(activity);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(ActivityInputModel model)
        {
            CreateActivityCommand command = new CreateActivityCommand(model.Id, model.Title, model.Description,
                                                                      model.OnDate, model.City,
                                                                      model.Venue);

            return await _commandManager.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, ActivityInputModel model)
        {
            EditActivityCommand command = new EditActivityCommand(id, model.Title, model.Description,
                                                                  model.OnDate, model.City,
                                                                  model.Venue);

            return await _commandManager.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _commandManager.Send(new DeleteActivityCommand(id));
        }

        private static ActivityResponse MapToResponse(Activity activity)
        {
            return new ActivityResponse
            {
                Id = activity.Id,
                City = activity.City,
                Title = activity.Title,
                Venue = activity.Venue,
                OnDate = activity.OnDate,
                Description = activity.Description,
                ActivityCategory = new ActivityCategoryResponse
                {
                    Id = activity.ActivityCategory.Id,
                    Name = activity.ActivityCategory.Name
                }
            };
        }

        private static List<ActivityResponse> MapToResponse(List<Activity> activities)
        {
            List<ActivityResponse> toReturn = new();

            foreach (Activity activity in activities)
            {
                toReturn.Add(new ActivityResponse
                {
                    Id = activity.Id,
                    City = activity.City,
                    Title = activity.Title,
                    Venue = activity.Venue,
                    OnDate = activity.OnDate,
                    Description = activity.Description,
                    ActivityCategory = new ActivityCategoryResponse
                    {
                        Id = activity.ActivityCategory.Id,
                        Name = activity.ActivityCategory.Name
                    },
                    ActivityCity = new ActivityCityResponse
                    {
                        Id = activity.ActivityCity.Id,
                        Name = activity.ActivityCity.City
                    }
                });
            }

            return toReturn;
        }
    }
}
