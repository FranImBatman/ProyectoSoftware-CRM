import { fetchProjectById } from "../services/projectService.js";
import { openEditTaskModal } from "../components/taskModal.js";

export async function reloadTaskTable(projectId) {
    const projectDetails = await fetchProjectById(projectId);

    const taskList = document.querySelector('#taskTableBody tbody');
    taskList.innerHTML = "";

    if (projectDetails.tasks && projectDetails.tasks.length > 0) {
        projectDetails.tasks.forEach(task => {
            const taskRow = document.createElement('tr');
            taskRow.innerHTML = `
                <td>${task.name}</td>
                <td>${task.assignedTo.name}</td>
                <td>${task.status.name}</td>
                <td>${new Date(task.dueDate).toLocaleDateString()}</td>
                <td>
                    <button class='edit-task'
                            data-task-id='${task.id}' 
                            data-task-name='${task.name}' 
                            data-task-due-date='${task.dueDate}' 
                            data-task-assigned-to='${task.assignedTo.id}' 
                            data-task-status='${task.status.id}'>
                        <i class="fa-solid fa-pen-to-square"></i>
                    </button>
                </td>               
            `;
            taskList.appendChild(taskRow);

            taskRow.querySelector('.edit-task').addEventListener('click', (event) => {
                openEditTaskModal(event.currentTarget);
            });
        });
    } else {
        taskList.innerHTML = '<tr><td colspan="4">No hay tareas asociadas a este proyecto.</td></tr>';
    }
}
