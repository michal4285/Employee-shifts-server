using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converters
{
    public static class Converter
    {

        public static TDTO ConvertToDTO<TEntity, TDTO>(TEntity Entity) where TEntity : DAL.IConvertable where TDTO : DTO.IConvertable
        {
            return Convert<TEntity, TDTO>(Entity);
        }

        public static TEntity ConvertToEntity<TDTO, TEntity>(TDTO DTO) where TDTO : DTO.IConvertable where TEntity : DAL.IConvertable
        {
            return Convert<TDTO, TEntity>(DTO);
        }
        private static T Convert<TEntity, T>(TEntity Entity)
        {
            Assembly asem = Assembly.GetAssembly(typeof(T));
            T o = (T)asem.CreateInstance(typeof(T).FullName);
            foreach (var prop in o.GetType().GetProperties())
            {
                if (Entity.GetType().GetProperty(prop.Name) != null)
                    prop.SetValue(o, Entity.GetType().GetProperty(prop.Name).GetValue(Entity));
            }
            return o;
        }



    }
}
