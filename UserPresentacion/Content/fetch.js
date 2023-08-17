


formulario.addEventListener('submit', (e) => {
    e.preventDefault();
    const dateInput = document.getElementById("inputZip");
    const selectedDate = dateInput.value;
    const nameInput = document.getElementById("nombre");
    const nameValue = nameInput.value;
    const selectElement = document.getElementById("inputState");
    const selectedValue = selectElement.value;

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
        toastr["error"]("Seleccione una fecha valida")
    } else {

        let usuario = {
            NameUser: nameValue,
            GenderUser: selectedValue,
            Birthdate: selectedDate
        };

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
                toastr["success"](res.message)
                formulario.reset()
            })


 
    }


 })




