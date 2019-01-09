using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace AzRBlog.Entities.Configs
{
    public class DateConvention : Convention
    {
        public DateConvention()
        {
            //Properties<DateTime>()
            //    .Configure(c => c.HasColumnType("datetime2").HasPrecision(3));

            Properties<DateTime>().Configure(c => c.HasColumnType("datetime"));
            Properties<DateTime>()
                .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
                .Any(a => a.DataType == DataType.Date))
                .Configure(c => c.HasColumnType("date"));
            Properties<DateTime>()
               .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
               .Any(a => a.DataType == DataType.Time))
               .Configure(c => c.HasColumnType("time").HasPrecision(7));
        }
    }
}
