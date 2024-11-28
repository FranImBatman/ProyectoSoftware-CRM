import { openEditTaskModal } from "../components/taskModal.js";
import { fetchProjectById } from "../services/projectService.js";

export function displayProjects(projects){    
    const tbody = document.getElementById('projects');
    tbody.innerHTML = '';

    projects.forEach(project => {
        const row = document.createElement('tr');
        row.innerHTML = `
            
        <td>${project.name}</td>
        <td>${project.client.name}</td>
        <td>${project.campaignType.name}</td>
        <td>${new Date(project.startDate).toLocaleDateString()}</td>
        <td>${new Date(project.endDate).toLocaleDateString()}</td>       
        <td>
            <button class="ver-detalles" p-id="${project.id}">
                <i class="fa-solid fa-bars"></i>
            </button>
            
        </td>
    `;
    
    tbody.appendChild(row);
        
    });

    const detailsButtons = document.querySelectorAll('.ver-detalles');
    detailsButtons.forEach(button => {
        button.addEventListener('click', (event) => {
            const projectId = event.target.closest('.ver-detalles').getAttribute('p-id');
            showProjectDetails(projectId);
        });
    });
}

export async function showProjectDetails(projectId){
    const projectDetails = await fetchProjectById(projectId);
    console.log('Data', projectDetails);
    if(!projectDetails){
        return;
    }

    const projectName = document.getElementById('project-name-title');
    const projectCampaignType = document.getElementById('project-campaign-type');
    const projectStartDate = document.getElementById('project-start-date');
    const projectEndDate = document.getElementById('project-end-date');

    const projectClientName = document.getElementById('client-name');
    const projectClientEmail = document.getElementById('client-email');
    const projectClientPhone = document.getElementById('client-phone');
    const projectClientCompany = document.getElementById('client-company');
    const projectClientAddress = document.getElementById('client-address');

    projectName.innerText = '';
    projectCampaignType.innerText = '';
    projectStartDate.innerText = '';
    projectEndDate.innerText = ''; 

    projectClientName.innerText = '';
    projectClientEmail.innerText = '';
    projectClientPhone.innerText = '';
    projectClientCompany.innerText = '';
    projectClientAddress.innerText = '';
    
    projectName.innerText = projectDetails.data.name;
    projectCampaignType.innerText = projectDetails.data.campaignType.name;
    projectStartDate.innerText = new Date(projectDetails.data.startDate).toLocaleDateString();
    projectEndDate.innerText = new Date(projectDetails.data.endDate).toLocaleDateString();

    projectClientName.innerText = projectDetails.data.client.name;
    projectClientEmail.innerText = projectDetails.data.client.email;
    projectClientPhone.innerText = projectDetails.data.client.phone;
    projectClientCompany.innerText = projectDetails.data.client.company;
    projectClientAddress.innerText = projectDetails.data.client.address;

    const addTaskProjectButton = document.querySelector('.add-task');
    addTaskProjectButton.setAttribute('data-project-id', projectId);

    const addInteractionProjectButton = document.querySelector('.add-interaction');
    addInteractionProjectButton.setAttribute('data-project-id', projectId);

    const taskList = document.querySelector('#taskTableBody tbody');
    taskList.innerHTML = "";
    
    if(projectDetails.tasks && projectDetails.tasks.length> 0){     
        
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

    const interactionList = document.querySelector('#interactionTableBody tbody');
    interactionList.innerHTML = '';

    if(projectDetails.interactions && projectDetails.interactions.length > 0){
        
        projectDetails.interactions.forEach(interaction => {
            const interactionRow = document.createElement('tr');
            interactionRow.innerHTML = `
                <td>${interaction.notes}</td>              
                <td>${interaction.interactionType.name}</td>
                <td>${new Date(interaction.date).toLocaleDateString()}</td>
            `;
            interactionList.appendChild(interactionRow);
        });

        
    } else {
        interactionList.innerHTML = '<tr><td colspan="3">No hay interacciones asociadas a este proyecto.</td></tr>';
    }
    
    var modal = document.querySelector('.project-details-modal');
    var overlay = document.getElementById('overlay');
    
    modal.style.display = 'block';
    overlay.style.display = 'block';
    setTimeout(function(){
        modal.classList.add('show');
    }, 10);


}

