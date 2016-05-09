function Configurafecha(maxDate, id, rangoFecha)
{
    if(maxDate)
    {
        $(id).datepicker({
            inline: true,
            changeMonth: true,
            changeYear: true,
            yearRange: rangoFecha,
            maxDate: "+0m +0d"
        });
    } else
    {
        $(id).datepicker({
            inline: true,
            changeMonth: true,
            changeYear: true,
            yearRange: rangoFecha,
        });
    }

}