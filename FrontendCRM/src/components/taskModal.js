import { resetModalOptions } from "../utils/modalUtils.js";

export function openCreateTaskModal(){
    document.getElementById('data-task-id').value = '';
    document.getElementById('task-modal-button-title').innerText = "Cargar tarea";
    document.querySelector('#dataTask .submit-button').innerText = "Agregar tarea";
    openModalAddTask();
}

export function openEditTaskModal(taskButton){
   
    const taskId = taskButton.getAttribute('data-task-id');
    const taskName = taskButton.getAttribute('data-task-name');
    const taskDueDate = new Date(taskButton.getAttribute('data-task-due-date'));
    const formattedDate = taskDueDate.toISOString().slice(0, 10);
    const assignedTo = taskButton.getAttribute('data-task-assigned-to');
    const status = taskButton.getAttribute('data-task-status');

    
    document.getElementById('create-task-name').value = taskName;
    document.getElementById('create-task-due-date').value = formattedDate;
    document.getElementById('create-task-user').value = assignedTo; 
    document.getElementById('create-task-status').value = status; 
    document.getElementById('data-task-id').value = taskId;

    document.getElementById('task-modal-button-title').innerText = "Editar tarea";
    document.querySelector('#dataTask .submit-button').innerText = "Guardar cambios";

    openModalAddTask();
}


export function openModalAddTask(){
    var modalTask = document.querySelector('.add-task-modal');
    var modalProject = document.querySelector('.project-details-modal');
    var overlay = document.getElementById('mid-overlay');
    modalProject.classList.add('dim');
    modalTask.style.display = 'block';
    overlay.style.display = 'block';
    setTimeout(function(){
        modalTask.classList.add('show');
    }, 500);

   
}

export function closeModalAddTask(){
    var modalTask = document.querySelector('.add-task-modal');
    var modalProject = document.querySelector('.project-details-modal');
    var overlay = document.getElementById('mid-overlay');
    modalTask.classList.remove('show');
    modalProject.classList.remove('dim');
    
    setTimeout(function(){
        modalTask.style.display = "none";  
        overlay.style.display = 'none'; 
    }, 500);

    resetModalOptions('dataTask');
}

