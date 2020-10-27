var baseURI = "https://localhost:44317/"


function addEmployee() {
    var name = document.getElementById("fname").value;
    var surname = document.getElementById("fsurname").value;
    var salary = parseInt(document.getElementById("fsalary").value);  // parseInt para convertir string a int
    var job = document.getElementById("fjob").value;

    var newEmployee = { Name: name, Surname: surname, Salary: salary, Job: job };

    $("ol").append("<li>Appended item</li>");

    $.ajax({
        type: "POST",
        url: baseURI + "api/Employees",
        data: JSON.stringify(newEmployee),
        contentType: 'application/json',
        success: function (response) {
            alert("post ok");
        },
        error: function (error) {
            console.log(error);        //console.log(error) especifica el error en la consola 
            alert("hay un problema")
        },
        dataType: "json"
    });
}


function getAllEmployee() {

    $('#employeeList tbody').empty();  //limpiamos la lista (solo el cuerpo asi mantenemos headers) para que no se duplique cuando volvamos a pulsar 

    $.ajax({
        type: "GET",
        url: baseURI + "api/Employees",
        dataType: "json",
        success: function (response) {

            if (response.length > 0) {

                response.forEach(function (item) {

                    $('#employeeList').append($('<tbody>')
                        .append($('<td>').append(item.employeeId))
                        .append($('<td>').append(item.name))     //FICAR PROPIETATS EN MINÚSCULES!!!!
                        .append($('<td>').append(item.surname))
                        .append($('<td>').append(item.job))
                        .append($('<td>').append(item.salary + ' €'))          
                        )    
                });  

            } else {
                pTest.outerText = "No tienes ningún empleado por el momento";
                alert("La lista está vacia");
            }
        },
        error: function (error) {
            alert("hay un problema")
        },

    });

}

function FireEmployee() {

    var fireEmploId = parseInt(document.getElementById("fireid").value);

    $.ajax({
        type: "DELETE",
        url: baseURI + "api/Employees/" + fireEmploId,
        contentType: 'application/json',
        success: function (response) {

            alert("delete ok");
        },
        error: function (error) {
            alert("hay un problema en delete");
            console.log(error);
        },
        dataType: "json"
    });
}

function editEmployee() {

    var edid = parseInt(document.getElementById("fid").value); 
    var edname = document.getElementById("fname").value;
    var edsurname = document.getElementById("fsurname").value;
    var edsalary = parseInt(document.getElementById("fsalary").value);  // parseInt para convertir string a int
    var edjob = document.getElementById("fjob").value;

    var edEmployee = { employeeId: edid, Name: edname, Surname: edsurname, Salary: edsalary, Job: edjob };
//fiquem employeeId perque no generi una nova id y por ende un nou employee --> donaria error 405
      $("ol").append("<li>Appended item</li>");

    $.ajax({
        type: "PUT",
        url: baseURI + "api/Employees/" + edid,
        data: JSON.stringify(edEmployee),
        contentType: 'application/json',
        success: function (response) {
            alert("edit ok");
        },
        error: function (error) {
            console.log(error);        //console.log(error) especifica el error en la consola 
            alert("edit problem")
        },
        dataType: "json"
    });
}