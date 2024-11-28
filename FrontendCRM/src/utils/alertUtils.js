export const successMessages = {
    project: 'Proyecto creado con exito!',
    task: 'Tarea cargada con exito!',
    editTask: 'Tarea modificada!',
    interaction: 'Interaccion cargada con exito!'
}

export const errorMessages = {
    project: 'Error al crear el proyecto! Intente nuevamente!',
    task: 'Error al cargar la tarea! Intente nuevamente!',
    editTask: 'Error al modificar la tarea! Intente nuevamente!',
    interaction: 'Error al cargar la interaccion! Intente nuevamente!',
    field: 'Faltan campos por completar!'
}

export function showSuccessAlert(message){
    
    const alertIcon = document.getElementById('success-alert-icon');
    const alertText = alertIcon.querySelector('.success-alert-text span');
    alertText.textContent = message;
    alertIcon.classList.add('show');
    alertIcon.style.display = 'flex'; 

    setTimeout(()=>{
        hideSuccessAlert();
    }, 2000)
}

function hideSuccessAlert(){
    const alert = document.getElementById('success-alert-icon');
    alert.classList.remove('show'); 

    
    setTimeout(() => {
        alert.style.display = 'none'; 
    }, 1500); 
}

export function showErrorAlert(message){
    const alertIcon = document.getElementById('error-alert-icon');
    const alertText = alertIcon.querySelector('.error-alert-text span');
    alertText.textContent = message;
    alertIcon.style.display = 'flex';
    alertIcon.classList.add('show');   
    setTimeout(() => {
        hideErrorAlert();
    }, 4000);
}

export function hideErrorAlert(){
    const alert = document.getElementById('error-alert-icon');
    alert.classList.remove('show');

    setTimeout(() => {     
        alert.style.display = 'none';
    }, 1500); 
}
