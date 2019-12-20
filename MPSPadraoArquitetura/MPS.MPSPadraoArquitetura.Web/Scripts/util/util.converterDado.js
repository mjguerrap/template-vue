function converterDado(statusTipoDadoId) {
    var retorno = "";

    switch (statusTipoDadoId) {
        case 1:
            retorno = "Bool";
            break;
        case 2:
            retorno = "Boolean";
            break;
        case 3:
            retorno = "Byte";
            break;
        case 4:
            retorno = "Byte[]";
            break;
        case 5:
            retorno = "Char";
            break;
        case 6:
            retorno = "Char[]";
            break;
        case 7:
            retorno = "DateTime";
            break;
        case 8:
            retorno = "DateTimeOffset";
            break;
        case 9:
            retorno = "Decimal";
            break;
        case 10:
            retorno = "Double";
            break;
        case 11:
            retorno = "Enum";
            break;
        case 12:
            retorno = "Float";
            break;
        case 13:
            retorno = "Guid";
            break;
        case 14:
            retorno = "Int";
            break;
        case 15:
            retorno = "Int16";
            break;
        case 16:
            retorno = "Int32";
            break;
        case 17:
            retorno = "Int64";
            break;
        case 18:
            retorno = "Long";
            break;
        case 19:
            retorno = "Object";
            break;
        case 20:
            retorno = "Sbyte";
            break;
        case 21:
            retorno = "Short";
            break;
        case 22:
            retorno = "Single";
            break;
        case 23:
            retorno = "String";
            break;
        case 24:
            retorno = "struct";
            break;
        case 25:
            retorno = "TimeSpan";
            break;
        case 26:
            retorno = "Uint";
            break;
        case 27:
            retorno = "Ulong";
            break;
        case 28:
            retorno = "Ushort";
            break;
        case 29:
            retorno = "Xml";
            break;
        default:
            retorno = "";
    }

    return retorno;
}