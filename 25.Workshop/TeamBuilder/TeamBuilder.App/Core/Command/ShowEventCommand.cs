﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
    public class ShowEventCommand : ICommand
    {
       public string Execute(string[] args)
        {

            Check.CheckLength(1, args);

            string eventName = args[0];

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            Event eventa = null;

            using (var context = new TeamBuilderContext())
            {
                eventa = context.Events
                    .Include(e => e.ParticipatingTeamEvents)
                    .ThenInclude(pet => pet.Team)
                    .OrderByDescending(e => e.StartDate)
                    .First(e => e.Name == eventName);
            }

            var sb = new StringBuilder();

            sb.AppendLine($"{eventa.Name} {eventa.StartDate.ToString(Constants.DateTimeFormat)} {eventa.EndDate.ToString(Constants.DateTimeFormat)}");
            sb.AppendLine($"{eventa.Description}");
            sb.AppendLine($"Teams:");

            foreach (var pet in eventa.ParticipatingTeamEvents)
            {
                sb.AppendLine($"-{pet.Team.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
