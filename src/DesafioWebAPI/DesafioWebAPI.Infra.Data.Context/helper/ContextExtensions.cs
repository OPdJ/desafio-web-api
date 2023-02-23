using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DesafioWebAPI.Infra.Data.Context.helper
{
    // https://www.red-gate.com/simple-talk/blogs/change-delete-behavior-and-more-on-ef-core/
    public static class ContextExtensions
    {
        private static List<Action<IMutableEntityType>> Conventions = new List<Action<IMutableEntityType>>();

        public static void RemovePluralizeBehavior(this ModelBuilder builder)
        {
            Conventions.Add(et => et.SetTableName(et.DisplayName()));
        }

        public static void ApplyConventions(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (Action<IMutableEntityType> action in Conventions)
                    action(entityType);
            }

            Conventions.Clear();
        }
    }
}
