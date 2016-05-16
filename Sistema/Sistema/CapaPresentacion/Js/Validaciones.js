function okValidacion(div, span1, span2) {
    document.getElementById(div).className = "form-group has-feedback has-success";
    document.getElementById(span1).className = "glyphicon form-control-feedback icon-checkmark";
    document.getElementById(span2).innerHTML = "";
}

function errorValidacion(div, span1, span2, mensaje) {
    document.getElementById(div).className = "form-group has-feedback has-error";
    document.getElementById(span1).className = "glyphicon form-control-feedback icon-cross";
    document.getElementById(span2).innerHTML = mensaje;
}


var validacion = null;

function revisar(divId, elemento) {
    //alert(elemento.className);
    //if (elemento.value == "") {
    //    elemento.className = 'form-group has-success has-feedback';
    //} else {
    //    elemento.className = 'form-group has-success has-feedback';
    //}
    espacioEnBlanco(elemento);


    if (validacion == true) {
        alert(divId + "    " + elemento);
        document.getElementById(divId).setAttribute("class", "form-group has-success has-feedback");
        validacion = null;
    } else {
        alert(divId + "    " + elemento);
        document.getElementById(divId).setAttribute("class", "form-group has-error has-feedback");
        validacion = null;
    }
}

function idVal(elemento, cedID, pasID, resID, div, span1, span2) {

    if (document.getElementById(cedID).checked) {

        soloNumeros(elemento);

        if (validacion == true) {
            okValidacion(div, span1, span2);
            validacion = null;
        } else {
            errorValidacion(div, span1, span2, 'Solo se permiten 9 numeros');
            validacion = null;
        }
    }

    if (document.getElementById(pasID).checked) {

        espacioEnBlanco(elemento);
        if (validacion == true) {
            okValidacion(div, span1, span2);
            validacion = null;
        } else {
            errorValidacion(div, span1, span2, 'Pasaporte incorrecto');
            validacion = null;
        }
    }

    if (document.getElementById(resID).checked) {
        espacioEnBlanco(elemento);
        if (validacion == true) {
            okValidacion(div, span1, span2);
            validacion = null;
        } else {
            errorValidacion(div, span1, span2, 'Cedula de residencia incorrecta');
            validacion = null;
        }
    }

}


function emailVal(elemento, div, span1, span2) {
    correoElectronico(elemento);

    if (validacion == true) {
        okValidacion(div, span1, span2);
        validacion = null;
    } else {
        errorValidacion(div, span1, span2, 'Correo electrónico incorrecto');
        validacion = null;
    }
}

function textVal(elemento, div, span1, span2) {
    var x = soloLetras(elemento);
    switch (x) {
        case 0:
            okValidacion(div, span1, span2);
            break;
        case 1:
            errorValidacion(div, span1, span2, 'Debe rellenar el campo');
            break;
        case 2:
            errorValidacion(div, span1, span2, 'No se permite espacios al inicio');
            break;
        case 3:
            errorValidacion(div, span1, span2, 'Solo se permiten letras');
            break;
    }
}


function correoElectronico(elemento) {
    if (elemento.value != "") {
        var dato = elemento.value;
        var expresion = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
        if (!expresion.test(dato)) {
            validacion = false;
        } else {
            validacion = true;
        }
    }

}

function espacioEnBlanco(elemento) {
    if (elemento.value != "") {
        var dato = elemento.value;
        var expresion = /^\s+$/
        if (dato.length == 0 || expresion.test(dato) || dato == null) {
            validacion = false;
        } else {
            validacion = true;
        }
    }

}

function soloNumeros(elemento) {
    var dato = elemento.value;
    if (elemento.value == "") {
        return 1;
    }
    else if (dato[0] == " ") {
        return 2;
    }
    else if (dato[0] == "-") {
        return 3;
    }
    else if (isNaN(dato)) {
        return 4;
    }
    else {
        return 0;
    }
}

function soloLetras(elemento) {
    var letters = /^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$/;
    var cadena = elemento.value;
    if (cadena == "") {
        return 1;
    }
    else if (cadena[0] == " ") {
        return 2;
    }
    else if (!elemento.value.match(letters)) {
        return 3;
    } else {
        return 0;
    }
}

function espaciosVal(elemento, div, span1, span2) {
    espacioEnBlanco(elemento);

    if (validacion == true) {
        okValidacion(div, span1, span2);
        validacion = null;
    } else {
        errorValidacion(div, span1, span2, 'No se permiten espacios en blanco');
        validacion = null;
    }
}

function numerosVal(elemento, div, span1, span2) {
    var x = soloNumeros(elemento);
    switch (x) {
        case 0:
            okValidacion(div, span1, span2);
            break;
        case 1:
            errorValidacion(div, span1, span2, 'Debe rellenar el campo');
            break;
        case 2:
            errorValidacion(div, span1, span2, 'No se permite espacios al inicio');
            break;
        case 3:
            errorValidacion(div, span1, span2, 'No se permiten números negativos');
            break;
        case 4:
            errorValidacion(div, span1, span2, 'Solo se permiten números sin espacios');
            break;

    }
}

function noEspeciales(elemento) {
    var letters = /^[A-Za-zñÑáéíóúÁÉÍÓÚ0123456789 ]+$/;
    var cadena = elemento.value;
    if (cadena[0] != " ") {
        if (elemento.value.match(letters)) {
            validacion = true;
        }
        else {
            validacion = false;
        }
    }
}

function letrasNumeros(elemento, div, span1, span2) {
    noEspeciales(elemento);

    if (validacion == true) {
        okValidacion(div, span1, span2);
        validacion = null;
    } else {
        errorValidacion(div, span1, span2, 'Solo se permiten espacios en blanco');
        validacion = null;
    }
}

function comboVal(elemento, div, span1, span2) {
    if (elemento.value != 0) {
        okValidacion(div, span1, span2);
    }
    else {
        errorValidacion(div, span1, span2, 'Debe seleccionar una opción');
    }
}

function usuarioVal(elemento, div, span1, span2) {
    var x = usuario(elemento);
    switch (x) {
        case 0:
            okValidacion(div, span1, span2);
            break;
        case 1:
            errorValidacion(div, span1, span2, 'Debe rellenar el campo');
            break;
        case 2:
            errorValidacion(div, span1, span2, 'No se permite espacios al inicio');
            break;
        case 3:
            errorValidacion(div, span1, span2, 'Solo se permiten letras minúsculas y los signos . y _');
            break;
        case 4:
            errorValidacion(div, span1, span2, 'Debe tener mínimo 8 caractes');
            break;
    }
}

function usuario(elemento) {
    var letters = /^[a-z_.]+$/;
    var cadena = elemento.value;
    if (cadena == "") {
        return 1;
    }
    else if (cadena[0] == " ") {
        return 2;
    }
    else if (!elemento.value.match(letters)) {
        return 3;
    }
    else if (cadena.length < 8) {
        return 4;
    }
    else {
        return 0;
    }
}




function contraseniaVal(elemento, div, span1, span2) {
    var x = contrasenia(elemento);
    switch (x) {
        case 0:
            okValidacion(div, span1, span2);
            break;
        case 1:
            errorValidacion(div, span1, span2, 'Debe rellenar el campo');
            break;
        case 2:
            errorValidacion(div, span1, span2, 'No se permite espacios al inicio');
            break;
        case 3:
            errorValidacion(div, span1, span2, 'No se permite espacios');
            break;
        case 4:
            errorValidacion(div, span1, span2, 'Debe tener mínimo 8 caractes');
            break;
    }
}

function contrasenia(elemento) {
    var cadena = elemento.value;
    if (cadena == "") {
        return 1;
    }
    else if (cadena[0] == " ") {
        return 2;
    }
    else if (cadena.indexOf(" ") != -1) {
        return 3;
    }
    else if (cadena.length < 8) {
        return 4;
    }
    else {
        return 0;
    }
}

function confirmContr(elemento1, elemento2, div, span1, span2) {

    if (document.getElementById(elemento1).value === elemento2.value) {
        okValidacion(div, span1, span2);
    } else {
        errorValidacion(div, span1, span2, 'Las contraseñas no coinciden');
    }
}

function soloNumerosCed(elemento) {
    var dato = elemento.value;
    var tamano = dato.length;
    if (elemento.value == "") {
        return 1;
    }
    else if (dato[0] == " ") {
        return 2;
    }
    else if (dato[0] == "-") {
        return 3;
    }
    else if (isNaN(dato)) {
        return 4;
    }
    else if (tamano < 9 || tamano > 9) {
        return 5;
    }
    else {
        return 0;
    }
}

function numerosCedVal(elemento, div, span1, span2) {
    var x = soloNumerosCed(elemento);
    switch (x) {
        case 0:
            okValidacion(div, span1, span2);
            break;
        case 1:
            errorValidacion(div, span1, span2, 'Debe rellenar el campo');
            break;
        case 2:
            errorValidacion(div, span1, span2, 'No se permite espacios al inicio');
            break;
        case 3:
            errorValidacion(div, span1, span2, 'No se permiten números negativos');
            break;
        case 4:
            errorValidacion(div, span1, span2, 'Solo se permiten números sin espacios');
            break;
        case 5:
            errorValidacion(div, span1, span2, 'Debe ingresar 9 números');
            break;

    }
}

function pasaportVal(elemento, div, span1, span2) {
    var x = pasaport(elemento);
    switch (x) {
        case 0:
            okValidacion(div, span1, span2);
            break;
        case 1:
            errorValidacion(div, span1, span2, 'Debe rellenar el campo');
            break;
        case 2:
            errorValidacion(div, span1, span2, 'No se permite espacios al inicio');
            break;
        case 3:
            errorValidacion(div, span1, span2, 'Solo se permiten números y letras sin espacios');
            break;
        case 4:
            errorValidacion(div, span1, span2, 'Debe tener mínimo 8 caractes');
            break;
    }
}

function pasaport(elemento) {
    var letters = /^[a-zA-Z1234567890]+$/;
    var cadena = elemento.value;
    if (cadena == "") {
        return 1;
    }
    else if (cadena[0] == " ") {
        return 2;
    }
    else if (!elemento.value.match(letters)) {
        return 3;
    }
    else if (cadena.length < 8) {
        return 4;
    }
    else {
        return 0;
    }
}

function identificacionVal(elemento, cedID, pasID, resID, id, div, span1, span2) {
    //var cadena = elemento.value;
    if (document.getElementById(cedID).checked) {
        document.getElementById(id).setAttribute("maxlength", 9);
        document.getElementById(cedula).value = "f";
        numerosCedVal(elemento, div, span1, span2);
    }
    else if (document.getElementById(pasID).checked) {
        document.getElementById(id).setAttribute("maxlength", 20);
        pasaportVal(elemento, div, span1, span2);

    }
    else if (document.getElementById(resID).checked) {
        document.getElementById(id).setAttribute("maxlength", 20);
        pasaportVal(elemento, div, span1, span2);

    }
}


function areaCons(id) {
    if (document.getElementById("span1Nombre").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Abrev").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Ubicacion").className == "glyphicon form-control-feedback icon-checkmark") {

        document.getElementById(id).removeAttribute("disabled");
    }
    else {
        document.getElementById(id).setAttribute("disabled", true);
    }

}

function brigadas(id) {
    if (document.getElementById("span1Nombre").className == "glyphicon form-control-feedback icon-checkmark") {

        document.getElementById(id).removeAttribute("disabled");
    }
    else {
        document.getElementById(id).setAttribute("disabled", true);
    }

}

function usuarios(id) {
    if (document.getElementById("span1Usuario").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Cedula").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Nombre").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Apellido1").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Apellido2").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Email").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Contrasenia").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Contrasenia2").className == "glyphicon form-control-feedback icon-checkmark") {

        document.getElementById(id).removeAttribute("disabled");
    }
    else {
        document.getElementById(id).setAttribute("disabled", true);
    }

}

function bombInfoPerson(id) {
    if (document.getElementById("span1Nombre").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1P_Ape").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1S_Ape").className == "glyphicon form-control-feedback icon-checkmark" &&
        //document.getElementById("span1Cedula").className == "glyphicon form-control-feedback icon-checkmark" &&          arreglar
        document.getElementById("span1Provincia").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Canton").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1LugarResid").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1TelResid").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1TelCel").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Ocupacion").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1Correo").className == "glyphicon form-control-feedback icon-checkmark" &&
        document.getElementById("span1AniosBrig").className == "glyphicon form-control-feedback icon-checkmark") {

        document.getElementById(id).removeAttribute("disabled");
    }
    else {
        document.getElementById(id).setAttribute("disabled", true);
    }

}

function identificacionV() {
    if (document.getElementById(cedID).checked) {
        document.getElementById(cedulaRB).value = "dsf";
    }
}


function ok(div, span1) {
    document.getElementById(div).className = "form-group has-feedback has-success";
    document.getElementById(span1).className = "glyphicon form-control-feedback icon-checkmark";
}

function malo(div, span1) {
    document.getElementById(div).className = "form-group has-feedback has-error";
    document.getElementById(span1).className = "glyphicon form-control-feedback icon-cross";
}

function validar(a, b, div, span1) {
    var x = document.getElementById(a);
    var y = document.getElementById(b);
    if (x.style.display == "inline" || y.style.display == "inline" || x.style.visibility == "visible" || y.style.visibility == "visible") {
        malo(div, span1);
    }
    else {
        ok(div, span1);
    }
}


function area() {
    if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator2").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_vUbicacion").style.visibility == "visible") {

        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "inline") {
            malo(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "inline") {
            malo(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "inline") {
            malo(document.getElementById("divAbreviatura").id, document.getElementById("span1Abrev").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator2").style.display == "inline") {
            malo(document.getElementById("divAbreviatura").id, document.getElementById("span1Abrev").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_vUbicacion").style.visibility == "visible") {
            malo(document.getElementById("divUbicacion").id, document.getElementById("span1Ubicacion").id);
        }
    }

    else if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator2").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_vUbicacion").style.visibility == "hidden") {

        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_NAreaCons").value != "") {
            ok(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_abrev").value != "") {
            ok(document.getElementById("divAbreviatura").id, document.getElementById("span1Abrev").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_vUbicacion").style.visibility == "hidden" && document.getElementById("ContentPlaceHolderContenido_ubicacion").value != "0") {
            ok(document.getElementById("divUbicacion").id, document.getElementById("span1Ubicacion").id);
        }
    }

}

function briga() {
    if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "visible") {
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "inline") {
            malo(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "inline") {
            malo(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "visible") {
            malo(document.getElementById("divAreaCons").id, document.getElementById("span1AreaCons").id);
        }
    }

    if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "hidden") {
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_brigada").value != "") {
            ok(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "hidden" && document.getElementById("ContentPlaceHolderContenido_areaCons").value != "0") {
            ok(document.getElementById("divAreaCons").id, document.getElementById("span1AreaCons").id);
        }
    }

}

function usuar() {
    if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator6").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator6").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator2").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator3").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator3").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator4").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator4").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator5").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator5").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator8").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_CompareValidator1").style.display == "inline" ||
        document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "visible") {

        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "inline") {
            malo(document.getElementById("divUsuario").id, document.getElementById("span1Usuario").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "inline") {
            malo(document.getElementById("divUsuario").id, document.getElementById("span1Usuario").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator6").style.display == "inline") {
            malo(document.getElementById("divCedula").id, document.getElementById("span1Cedula").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator6").style.display == "inline") {
            malo(document.getElementById("divCedula").id, document.getElementById("span1Cedula").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator2").style.display == "inline") {
            malo(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "inline") {
            malo(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator3").style.display == "inline") {
            malo(document.getElementById("divApellido1").id, document.getElementById("span1Apellido1").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator3").style.display == "inline") {
            malo(document.getElementById("divApellido1").id, document.getElementById("span1Apellido1").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator4").style.display == "inline") {
            malo(document.getElementById("divApellido2").id, document.getElementById("span1Apellido2").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator4").style.display == "inline") {
            malo(document.getElementById("divApellido2").id, document.getElementById("span1Apellido2").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator5").style.display == "inline") {
            malo(document.getElementById("divEmail").id, document.getElementById("span1Email").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator5").style.display == "inline") {
            malo(document.getElementById("divEmail").id, document.getElementById("span1Email").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator8").style.display == "inline") {
            malo(document.getElementById("divContrasenia").id, document.getElementById("span1Contrasenia").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_CompareValidator1").style.display == "inline") {
            malo(document.getElementById("divContrasenia2").id, document.getElementById("span1Contrasenia2").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "visible") {
            malo(document.getElementById("divAreaCons").id, document.getElementById("span1AreaCons").id);
        }
    }

    else if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator6").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator6").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator2").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator3").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator3").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator4").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator4").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator5").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator5").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator8").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_CompareValidator1").style.display == "none" ||
        document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "hidden") {

        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator1").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator1").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_usuario").value != "") {
            ok(document.getElementById("divUsuario").id, document.getElementById("span1Usuario").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator6").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator6").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_cedula").value != "") {
            ok(document.getElementById("divCedula").id, document.getElementById("span1Cedula").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator2").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator2").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_nombre").value != "") {
            ok(document.getElementById("divNombre").id, document.getElementById("span1Nombre").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator3").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator3").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_apellido1").value != "") {
            ok(document.getElementById("divApellido1").id, document.getElementById("span1Apellido1").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator4").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator4").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_apellido2").value != "") {
            ok(document.getElementById("divApellido2").id, document.getElementById("span1Apellido2").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator5").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_RegularExpressionValidator5").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_email").value != "") {
            ok(document.getElementById("divEmail").id, document.getElementById("span1Email").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_RequiredFieldValidator8").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_contrasenia").value != "") {
            ok(document.getElementById("divContrasenia").id, document.getElementById("span1Contrasenia").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_CompareValidator1").style.display == "none" && document.getElementById("ContentPlaceHolderContenido_confContrasenia").value != "") {
            ok(document.getElementById("divContrasenia2").id, document.getElementById("span1Contrasenia2").id);
        }
        if (document.getElementById("ContentPlaceHolderContenido_vAreaConservacion").style.visibility == "hidden" && document.getElementById("ContentPlaceHolderContenido_AreaCons").value != "0") {
            ok(document.getElementById("divAreaCons").id, document.getElementById("span1AreaCons").id);
        }
    }

}


function validarInputText(v1, v2, div, span) {

    var val1 = document.getElementById(v1);
    var val2 = document.getElementById(v2);
    //ValidatorValidate(val1);

    if (val1.isvalid && val2.isvalid) {
        document.getElementById(div).className = "form-group has-feedback has-success";
        document.getElementById(span).className = "glyphicon form-control-feedback icon-checkmark";
        //document.getElementById(span).innerHTML = "";
        //alert("valido");
    } else {
        document.getElementById(div).className = "form-group has-feedback has-error";
        document.getElementById(span).className = "glyphicon form-control-feedback icon-cross";
        //alert("invalido");
    }
}

function validarComboBox(v, div, span) {
    var val = document.getElementById(v);
    //ValidatorValidate(val1);

    if (val.isvalid) {
        document.getElementById(div).className = "form-group has-feedback has-success";
        //document.getElementById(span).className = "glyphicon form-control-feedback icon-checkmark";
        //document.getElementById(span).innerHTML = "";
        //alert("valido");
    } else {
        document.getElementById(div).className = "form-group has-feedback has-error";
        //document.getElementById(span).className = "glyphicon form-control-feedback icon-cross";
        //alert("invalido");
    }

}

function validarId(campo) {

    if (document.getElementById('cedulaRB').checked) {
        document.getElementById(campo).value = "";
        document.getElementById(campo).setAttribute("maxlength", 9);
        document.getElementById('divCedula').className = "form-group ";
        document.getElementById('span1Cedula').className = "";

    }
    if (document.getElementById('pasaporteRB').checked) {
        document.getElementById(campo).value = "";
        document.getElementById(campo).setAttribute("maxlength", 15);
        document.getElementById('divCedula').className = "form-group ";
        document.getElementById('span1Cedula').className = "";
    }
    if (document.getElementById('residenciaRB').checked) {
        document.getElementById(campo).value = "";
        document.getElementById(campo).setAttribute("maxlength", 15);
        document.getElementById('divCedula').className = "form-group ";
        document.getElementById('span1Cedula').className = "";
    }


}

function checkReseniaMedica(checkB, campo) {

    if (document.getElementById(checkB).checked) {
        document.getElementById(campo).disabled = false;

    }
    else {
        document.getElementById(campo).disabled = true;

        confirmar = confirm("Se borrará la informacion al desmarcar");
        if (confirmar) {

            document.getElementById(campo).value = "";
        }
        else {
            document.getElementById(campo).disabled = false;
            document.getElementById(checkB).checked = true;

        }
    }
}