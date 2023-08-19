// URL base para peticiones a API de usuarios
const url = '/User/Users';
// Estado de paginación  
let currentPage = 0;
const recordsPerPage = 4;
let totalRecords = 0;

// Referencias a elementos del DOM
const contenedor = document.getElementById("registro");
const search = document.getElementById("search");
const formulario2 = document.getElementById("formulario2");


// Función para formatear fecha
const formateaFecha = (fechas) => {
    // sacar el valor numérico de la cadena de fecha
    const unixTimestamp = parseInt(fechas.substring(6, fechas.length - 2));
    // convierte el valor Unix en un objeto Date
    const fecha = new Date(unixTimestamp);
    // Aplica el formato dia mes año
    const opcionesFormato = { year: 'numeric', month: 'numeric', day: 'numeric' };
    const fechaFormateada = fecha.toLocaleDateString(undefined, opcionesFormato);
    // devuleve la fecha formateada
    return fechaFormateada;
};

// Función para renderizar datos de usuarios
const renderData = (data) => {
      // Limpiar contenido anterior
    contenedor.innerHTML = "";
    // Recorrer data y agregar nuevos elementos al DOM
    data.forEach(item => {
        // Formatear fecha
        const fechaString = formateaFecha(item.Birthdate);

       // Agregar fila por usuario con datos
        contenedor.innerHTML += `
            <div class="row col-md-10 row-edit2 mb-3">
                <div class="col-md-3">
                    <p class="table-titulo">${item.NameUser}</p>
                </div>
                <div class="col-md-3">
                    <p class="table-titulo">${fechaString}</p>
                </div>
                <div class="col-md-3">
                    <p class="table-titulo">${item.GenderUser}</p>
                </div>
                <div class="col-md-3 d-flex justify-content-center">
                    <i class='bx bxs-edit editar' style="font-size: 20px;cursor: pointer;" data-toggle="modal" data-target="#exampleModal" data-value="${item.IdUser}"></i>
                    <i class='bx bxs-trash-alt ml-2 eliminar' style="color:red; font-size:20px; cursor: pointer;" data-value="${item.IdUser}"></i>
                </div>
            </div>`;
    });
     // Agregar listener para eliminar
    const deleteElements = document.querySelectorAll('.eliminar');
    deleteElements.forEach(deleteIcon => {
        deleteIcon.addEventListener('click', () => {
            const dataValue = deleteIcon.dataset.value;
            handleDelete(dataValue);
        });
    });
};

// Función para eliminar usuario
const handleDelete = (dataValue) => {
     // Petición DELETE al backend
    fetch(`/User/Delete?id=${dataValue}`)
        .then(res => res.json())
        .then(res => {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut",
                "hideMethod": "fadeOut"
            };
             // Mostrar notificación  
            toastr["success"](res.message);
            // Actualizar paginación
            updatePage(currentPage);
        });
};

// Función para actualizar paginación
const updatePage = (page) => {
    // Calcular rangos de paginación
    currentPage = page;
    const start = currentPage * recordsPerPage;
    const end = start + recordsPerPage;
     // Petición para obtener datos paginados
    fetch(url)
        .then(res => res.json())
        .then(res => {
            // Obtener total de registros  
            totalRecords = res.length;
            // Obtener data a renderizar
            const dataToRender = res.slice(start, end);
            renderData(dataToRender);

            const editIcons = document.querySelectorAll('.editar');
            editIcons.forEach(editIcon => {
                editIcon.addEventListener('click', () => {
                    const dataValue = editIcon.dataset.value;
                    fetch(`/User/SearchUserId?id=${dataValue}`)
                        .then(res => res.json())
                        .then(handleEdit);
                });
            });
        });
};
// Función al editar
const handleEdit = (res) => {
    const nombre = document.querySelector('#nombre2');
    const ids = document.querySelector('#ids');
      // Poblar valores en formulario
    nombre.value = res[0].NameUser;
    ids.value = res[0].IdUser;
};
// Búsqueda por nombre
const searchUser = (letter) => {
      // Petición para búsqueda
    fetch(`/User/SearchUser?name=${letter}`)
        .then(res => res.json())
        .then(renderData);
};
// Inicializar paginación
updatePage(currentPage);
// Listeners paginación
document.querySelector('.bx-chevron-left').addEventListener('click', () => {
    if (currentPage > 0) {
         // Actualizar paginación
        updatePage(currentPage - 1);
    }
});

document.querySelector('.bx-chevron-right').addEventListener('click', () => {
    const totalPages = Math.ceil(totalRecords / recordsPerPage);
    if (currentPage < totalPages - 1) {
         // Actualizar paginación
        updatePage(currentPage + 1);
    }
});
// Listener búsqueda
search.addEventListener("keyup", () => {
    const valor = search.value;
      // Llamar búsqueda o reset
    valor === "" ? updatePage(currentPage) : searchUser(valor);
});

document.querySelector('.atras').addEventListener('click', () => {
    window.location.href = '/';
});
// Formulario para editar y Listener para el mismno
formulario2.addEventListener('submit', (e) => {
    e.preventDefault();
    const dateInput = document.getElementById("inputZip2");
    const selectedDate = dateInput.value;
    const nameInput = document.getElementById("nombre2");
    const nameValue = nameInput.value;
    const selectElement = document.getElementById("inputState2");
    const selectedValue = selectElement.value;
    const ids = document.getElementById("ids");
    const idsValue = ids.value;
     // Validaciones
    if (nameValue === "") {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut",
            "hideMethod": "fadeOut"
        };
        toastr["error"]("El campo nombres no puede ir vacío");
    } else if (selectedDate === "") {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut",
            "hideMethod": "fadeOut"
        };
        toastr["error"]("Seleccione una fecha valida");
    } else {
        const usuario = {
            NameUser: nameValue,
            Birthdate: selectedDate,
            GenderUser: selectedValue,
            IdUser: idsValue,
        };
         // Petición PUT para actualizar
        fetch("/User/UpUser", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(usuario)
        }).then(res => res.json())
            .then(res => {
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": true,
                    "positionClass": "toast-bottom-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut",
                    "hideMethod": "fadeOut"
                };
                 // Mostrar notificaciones
                toastr["success"](res.message);
                formulario2.reset();
                  // Recargar datos
                updatePage(currentPage);
                   // Ocultar modal
                $('#exampleModal').modal('hide');
                document.getElementById('exampleModal').style.display = 'none';
            });
    }
});
