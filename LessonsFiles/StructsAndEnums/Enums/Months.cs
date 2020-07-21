//Relevant Docs, Enum: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum

namespace StructsAndEnums.Enums
{
    //Enums by default saves the data as an int type, this can be overriden using ':' followed by the value type.
    //you can also assign a specific value to each one or to only one and the next will automaticly change the rest(+1)
    enum Months //: byte
    {        
        Jan,            //Jan  =   0
        Feb,            //Feb  =   1
        Mar,            //Mar  =   2
        Apr,            //Apr  =   3
        Jun,            //Jun  =   4
        Jul,            //Jul  =   5
        Aug,            //Aug  =   6
        Sep,            //Sep  =   7
        Oct,            //Oct  =   8
        Nov,            //Nov  =   9
        Dec             //Dec  =   10
    }
}
