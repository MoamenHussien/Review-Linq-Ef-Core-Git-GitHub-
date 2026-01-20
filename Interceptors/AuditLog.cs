using ConsoleApp1.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interceptors
{
    public class AuditLog : SaveChangesInterceptor
    {
        public override InterceptionResult<int> 
            SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var dbcontext = eventData.Context;
            if (dbcontext == null) { return result; };
            foreach(var item in  dbcontext.ChangeTracker.Entries<I_AuditLog>())
            {
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.CreateAt = DateTime.Now;
                }
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    item.Entity.UpdateAt=DateTime.Now;
                }
            }
            return result;
        }
    }
}
