using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solinia
{
    public static class ObjectExt
    {
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            if (source == null || dest == null)
                return;

            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    { // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }

            }

        }

        public static void CopyFieldsTo<T, TU>(this T source, TU dest)
        {
            if (source == null || dest == null)
                return;

            var sourceFields = typeof(T).GetFields().ToList();
            var destFields = typeof(TU).GetFields()
                    .ToList();

            foreach (var sourceField in sourceFields)
            {
                if (destFields.Any(x => x.Name == sourceField.Name))
                {
                    var f = destFields.First(x => x.Name == sourceField.Name);
                    f.SetValue(dest, sourceField.GetValue(source));
                }

            }

        }
    }
}
