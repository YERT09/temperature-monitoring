// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Usuario: Hacienda
// Contraseña: 123456789

window.onload = function () {
    $("button").click(ingreso);
    $("#colMenu").hide();
    google.charts.load('current', { 'packages': ['corechart'] });
}

var bool = false;
let getdatos;
let rutinebool;


//funciones de tiempo
function repetirCadaSegundo() {
    identificadorIntervaloDeTiempo = setInterval(GetDatos, 500);
    rutinebool = setInterval(boolGrafica, 200);
}

function boolGrafica() {
    bool = true;
}

/*Actualización de datos cada 500ms */
function GetDatos() {
    var nmDv = [];
    var valores = [];
    var fechas = [];
    var listaDatos;
    /*Primera petición: obtiene los ids de los dispositivos*/
    $.ajax({
        method: "GET",
        url: "/Servicios/nDevice"
    }).done(function (msg) {
        nmDv = msg;
        /*segunda petición: Obtiene los datos medidos por dispositivo*/
        for (let i = 0; i < nmDv.length; i++)
        {
            valores = [];
            fechas = [];
            
            $.ajax({
                method: "GET",
                url: "/Servicios/getDevice?id="+nmDv[i]
            }).done(function (msg) {
                if (msg[0]!="[]") {
                    listaDatos = JSON.parse(msg[0]);

                    for (let k = 0; k < listaDatos.length; k++) {
                        valores.push(listaDatos[k].Valor);
                        fechas.push(listaDatos[k].Fecha);
                    }

                    /*por condiciones de carrera el ciclo se ejecuta primero que la impresión de pantalla
                     *es por ello que se crea una función que cada 2 segundos habilita para hacer la grafica 
                    */
                    if (bool == true) {
                        bool = false;
                        google.charts.setOnLoadCallback(function () { drawChart(nmDv[i], valores) });
                    }
                    

                    $("#" + nmDv[i] + ">.temperatura").text("Temperatura actual:" + valores[valores.length - 1] + "°C");
                    $("#" + nmDv[i] + ">.fecha").text("Actualizado:" + fechas[fechas.length - 1]);
                    $("." + nmDv[i] + "-td").text(valores[valores.length - 1] + "°C");
                    if (valores[valores.length - 1] > msg[1])
                        $("#" + nmDv[i] + ">.rango").text("Temp. alta");
                    else if (valores[valores.length - 1] < msg[2])
                        $("#" + nmDv[i] + ">.rango").text("Temp. baja");
                    else
                        $("#" + nmDv[i] + ">.rango").text("En rango");
                }

            });
        }
        
        datos = [];
    });

}

/*Login */
function ingreso() {
    $.ajax({
        method: "GET",
        url: "/Seguridad/Login?user=" + $("#user").val() +"&password="+$("#password").val()
    }).done(function (msg) {
        if (msg == "Usuario o Contraseña invalidos")
            alert("Error:" + msg);
        else {
            $("#colMenu").show();
            repetirCadaSegundo();
            $(".login").hide();
            var height = $(window).height();
            $("#divMenu").height(height / 1.19);
            $(".menu").click(service);
        }
    });
}

/*Llama a cada una de las funciones del menu*/
function service(event) {
    if (event.target.id == "menu_dispositivo")
        Dispositivo();
    if (event.target.id == "menu_contraseña")
        Contra();
    if (event.target.id == "menu_monitoreo")
        Monitoreo();
}

/*Vista y llenado de tabla de dispositivos */
function Dispositivo() {

    $(".menu").addClass("colornormal");
    $("#menu_dispositivo").removeClass("colornormal");
    $("#menu_dispositivo").addClass("cambioColor");
    $.ajax({
        method: "GET",
        url: "/Tablas/Device"
    }).done(function (msg) {
        $("#tablas").html(msg);
        $("#agregarDevice").click(agregar);
    });

    $.ajax({
        method: "GET",
        url: "/Servicios/ListDevice"
    }).done(function (msg) {
        var datos = JSON.parse(msg);
        for (var j = 0; j < datos.length; j++) {
            var htmlTags =
                `<tr class="${datos[j].Id}-tr">
                  <td>${j + 1}   Id(DB)=${datos[j].Id}</td>
                  <td>${datos[j].Nombre}</td>
                  <td class="${datos[j].Id}-td"> </td>
                  <td class="${datos[j].Id}-max"> ${datos[j].Max}°C</td>
                  <td class="${datos[j].Id}-min"> ${datos[j].Min}°C</td>
                  <td> <i id="${datos[j].Id}-t" class="fa fa-trash-o" aria-hidden="true"></i>  <i id="${datos[j].Id}-c" class="fa fa-cog" aria-hidden="true"></i> </td>
                </tr>`;
            $("#table_user").append(htmlTags);
        }
        $("td>i").click(crud);
    });
}

/*Vista de cambiar contreaseña*/
function Contra() {
    $(".menu").addClass("colornormal");
    $("#menu_contraseña").removeClass("colornormal");
    $("#menu_contraseña").addClass("cambioColor");
    $.ajax({
        method: "GET",
        url: "/Tablas/CambioContra"
    }).done(function (msg) {
        $("#tablas").html(msg);
        $("#btnOKContra").click(cambioContra);
        $("#btnCanContra").click(Dispositivo);
    });
}

/*Funciones cambio de contraseña*/
function cambioContra() {

    if ($("#ccontra").val() == "")
        alert("Escriba una contraseña");
    else if ($("#ncontra").val() == $("#ccontra").val() && $("#ccontra").val() != "") {
        $.ajax({
            method: "POST",
            url: "/Servicios/cambioContra",
            data: { password: $("#ncontra").val() }
        }).done(function (msg) {
            alert(msg)
            Dispositivo();
        });
    }
    else {
        alert("La confirmación de la contraseña es incorrecta");
        $("#ccontra").val("");
    }

}

/*Vista el monitoreo*/
function Monitoreo() {
    $(".menu").addClass("colornormal");
    $("#menu_monitoreo").removeClass("colornormal");
    $("#menu_monitoreo").addClass("cambioColor");

    $.ajax({
        method: "GET",
        url: "/Tablas/monitoreo"
    }).done(function (msg) {
        $("#tablas").html(msg);
    });
}

/*Llama a la funcion de editar o elimina dispositivos */ 
function crud(event) {
    var doc = (event.target.id).split("-");
    //elimina el dispositivo
    if (doc[1] == "t") {
        $.ajax({
            method: "POST",
            url: "/Servicios/elimDevice",
            data: { num: doc[0] }
        }).done(function (msg) {
            Dispositivo()
            alert(msg)
        });
    }
    //edita el dispositivo
    else if (doc[1] == "c") {
        $.ajax({
            method: "GET",
            url: "/Tablas/editDevice",
        }).done(function (msg) {
            $("#tablas").html(msg);
            $("#btnOKedit").click(function () { editDivice(doc[0])});
            $("#btnCanedit").click(Dispositivo);
        });
    }
}

/*Función editar dispositivo*/
function editDivice(num) {
    $.ajax({
        method: "POST",
        url: "/Servicios/editaDispositivo",
        data: { D_id:num , nombre: $("#a_name").val(), max: $("#a_max").val(), min: $("#a_min").val() }
    }).done(function (msg) {
        alert(msg)
        Dispositivo();
    });
}

/*Vista agregar dispositivo*/
function agregar() {

    $.ajax({
        method: "GET",
        url: "/Tablas/agregar"
    }).done(function (msg) {
        $("#tablas").html(msg);
        $("#btnOK").click(addDivice);
        $("#btnCan").click(Dispositivo);
    });
}

/*Función agregar dispositivo*/
function addDivice() {
    $.ajax({
        method: "POST",
        url: "/Servicios/agregaDispositivo",
        data: { nombre: $("#a_name").val(), max: $("#a_max").val(), min: $("#a_min").val()}
    }).done(function (msg) {
        alert(msg)
        Dispositivo();
    });
}


/*Funcion grafica*/
function drawChart(idclass, valores) {
    var datos = new Array();
    var cont = 0;
    datos.push(['N°', 'TEMP']);

    //Si es mayor a 100 el conteo empieza desde la diferencia para 
    //graficar los ultimos 100 datos
    if (valores.length > 100)      
        cont = valores.length - 100;

    for (let j = cont; j < valores.length && j < 100; j++) {
            datos.push([j, valores[j]]);
    }
    var data = google.visualization.arrayToDataTable(datos);
    var options = {
        title: 'Temperatura',
        curveType: 'function',
        legend: { position: 'bottom' }
    };
    var chart = new google.visualization.LineChart(document.getElementById(idclass + "-graf"));
    chart.draw(data, options);

}
