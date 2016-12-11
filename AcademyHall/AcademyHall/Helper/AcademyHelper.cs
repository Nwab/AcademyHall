using AcademyHall.DataLink;
using AcademyHall.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace AcademyHall.Helper
{

   public class AcademyHelper
    {

       public enum ChangeType
       {
           Delete = 1,
           Insert,
           Update
       }

        public void SaveModifiedChanges(AcademyHallDbContext dbChangeTracker, ChangeType changeType)
        {
            try
            {
                AcademyHallDbContext db = new AcademyHallDbContext();
                List<DbEntityEntry> modifiedAuditedEntities = new List<DbEntityEntry>();
                if (changeType.Equals(ChangeType.Insert))
                {
                    modifiedAuditedEntities = dbChangeTracker.ChangeTracker.Entries().Where(p => p.State == EntityState.Added).ToList();
                }
                else if (changeType.Equals(ChangeType.Update))
                {
                    modifiedAuditedEntities = dbChangeTracker.ChangeTracker.Entries().Where(c => c.State == EntityState.Modified).ToList();
                }
                else if (changeType.Equals(ChangeType.Delete))
                {
                    modifiedAuditedEntities = dbChangeTracker.ChangeTracker.Entries().Where(d => d.State == EntityState.Deleted).ToList();
                }

                var now = DateTime.Now;

                foreach (DbEntityEntry change in modifiedAuditedEntities)
                {
                    var entityName = change.Entity.GetType().Name;
                    var primaryKey = dbChangeTracker.GetPrimaryKeyValue(change);

                    AuditRecord audRecord = new AuditRecord()
                    {
                        DateCreated = now,
                        TableKey = primaryKey.ToString(),
                        TableName = entityName,
                        UserAction = changeType.ToString(),
                        Username = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name,
                    };
                    db.AuditRecords.Add(audRecord);
                    db.SaveChanges();
                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        var originalValue = (change.OriginalValues[prop] == null) ? "N/A" : (change.OriginalValues[prop].ToString());
                        string currentValue = (change.CurrentValues[prop] == null) ? "N/A" : (change.CurrentValues[prop].ToString());
                        if (!changeType.Equals(ChangeType.Delete))
                        {
                            currentValue = (change.CurrentValues[prop] == null) ? "N/A" : (change.CurrentValues[prop].ToString());
                        }

                        if (originalValue != currentValue)
                        {
                            AuditRecordField auditRecFld = new AuditRecordField()
                            {
                                AuditRecordId = audRecord.AuditRecordId,
                                MemberName = prop,
                                OldValue = originalValue,
                                NewValue = currentValue
                            };
                            db.AuditRecordFields.Add(auditRecFld);
                            db.SaveChanges();
                        }
                    }
                    // entity.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}