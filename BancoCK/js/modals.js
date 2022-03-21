function alerta(mensaje) {
    swal({
        icon: "info",
        html: "<h2 style='color:white'>" + 'Advertencia' + "</h2>",
        background: '#D03737',
        html: "<p style='color:white'; font-size:18px>" + mensaje + "</p>",
        confirmButtonColor: '#0C1248',
        footer: "<p style='color:white'; font-size:18px>" + 'Banco BCK' + "</p>",
    });

}


function notificacion(mensaje) {
    swal({
        icon: "info",
        html: "<h2 style='color:white'>" + 'Advertencia' + "</h2>",
        background: '#0C1248',
        html: "<p style='color:white'; font-size:18px>" + mensaje + "</p>",
        confirmButtonColor: '#D03737',
        footer: "<p style='color:white'; font-size:18px>" + 'Banco BCK' + "</p>",
    });
}



