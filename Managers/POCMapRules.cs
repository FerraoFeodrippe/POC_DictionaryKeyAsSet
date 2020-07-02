using System;
using System.Collections.Generic;
using System.Text;

namespace POC_SetToRules.Managers
{
    using Rules;

    public class POCMapRules
    {
        private static readonly ISet<string> _upDowngrade = new HashSet<string> { "UpDowngrade" };
        private static readonly ISet<string> _faixaPreco = new HashSet<string> { "Faixa de Preço" };
        private static readonly ISet<string> _upDowngradeParcelamento = new HashSet<string> { "UpDowngrade", "Parcelamento" };
        private static readonly ISet<string> _upDowngradeALaCarte = new HashSet<string> { "UpDowngrade", "ALaCarte" };
        private static readonly ISet<string> _broad = new HashSet<string> { "Broad" };

        public readonly Tuple<ISet<string>, ISet<Func<bool>>>[] Map;

        public POCMapRules(POCRules rules)
        {
           Map = new Tuple<ISet<string>, ISet<Func<bool>>>[]
           {
                new Tuple<ISet<string>, ISet<Func<bool>>> ( null, rules.GeneralRules),

                new Tuple<ISet<string>, ISet<Func<bool>>> ( _upDowngrade, rules.Bundle1),
                new Tuple<ISet<string>, ISet<Func<bool>>> ( _faixaPreco, rules.Bundle1 ),
                new Tuple<ISet<string>, ISet<Func<bool>>> ( _upDowngradeParcelamento, rules.Bundle2),
                new Tuple<ISet<string>, ISet<Func<bool>>> ( _upDowngradeALaCarte, rules.Bundle3),
                new Tuple<ISet<string>, ISet<Func<bool>>> ( _broad, rules.Bundle4)
           };
        }

    }
}
