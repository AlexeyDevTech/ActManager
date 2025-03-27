using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ActManager.Forms.Helpers
{
    public class EnumSource : MarkupExtension
    {
        private readonly Type _enumType;

        public EnumSource(Type enumType)
        {
            _enumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
            if (!_enumType.IsEnum)
                throw new ArgumentException("Type must be an enum", nameof(enumType));
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(_enumType);
        }
    }
}
