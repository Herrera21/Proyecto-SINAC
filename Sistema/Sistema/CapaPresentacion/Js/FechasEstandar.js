function Configurafecha(maxDateD, id, rangoFecha) {
    if (maxDateD) {
        $(id).datepicker({
            inline: true,
            changeMonth: true,
            changeYear: true,
            yearRange: rangoFecha,
            maxDate: maxDateD,
        });
    } else {
        $(id).datepicker({
            inline: true,
            changeMonth: true,
            changeYear: true,
            yearRange: rangoFecha,
        });
    }

}