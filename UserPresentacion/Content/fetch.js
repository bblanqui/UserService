// Escuchar el submit del formulario
formulario.addEventListener('submit', (e) => {
      // Prevenir comportamiento default del submit
    e.preventDefault();
      // Obtener valores de los inputs del formulario
    const dateInput = document.getElementById("inputZip");
    const selectedDate = dateInput.value;
    const nameInput = document.getElementById("nombre");
    const nameValue = nameInput.value;
    const selectElement = document.getElementById("inputState");
    const selectedValue = selectElement.value;
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
        }
        // Mostrar error si nombre está vacío
        toastr["error"]("El campo nombres no puede ir vacío")
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
        }
            // Mostrar error si fecha no está seleccionada
        toastr["error"]("Seleccione una fecha valida")
    } else {
        // Si pasa las validaciones, crear objeto usuario
        let usuario = {
            NameUser: nameValue,
            GenderUser: selectedValue,
            Birthdate: selectedDate
        };
            // Enviar petición POST al backend
        fetch("User/Create",{
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
                }
                  // Mostrar notificación de éxito
                toastr["success"](res.message)
                 // Reset formulario
                formulario.reset()
            })

 
    }

 })




