namespace LfSync.LcmModelGenerator
{

    /**


            var modelGenerator = new RelationalSourceGenerator()
                .OnStart("""
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIL.LCModel.EFCore;

""")
                .OnEntityStart(clazz => {

                    var _abstract = clazz.Abstract ? " abstract" : "";
                    var _base = clazz.BaseClass != null ? $" : {clazz.BaseClass.Name}" : "";
                    return $$"""
public{{_abstract}} class {{clazz.Name}}{{_base}}
{
""";
                })
                .OnEntityEnd("""
}

""")
              
              */

    internal class RelationalSourceGenerator
    {
        private readonly string _fileName;

        internal RelationalSourceGenerator(string fileName)
        {
            _fileName = fileName;
        }
    }
}