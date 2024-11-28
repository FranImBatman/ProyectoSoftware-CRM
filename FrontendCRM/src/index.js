import { addProject, loadProjects} from "./controllers/projectControllers.js";
import { initializeAllSelectors } from "./utils/selectorsUtils.js";
import { openModalAddProject, closeModalAddProject, closeModalProject } from "./components/projectModal.js";
import { openCreateTaskModal, closeModalAddTask } from "./components/taskModal.js";
import { openModalAddInteraction, closeModalAddInteraction } from "./components/interactionModal.js";
import { addInteractionToProject } from "./controllers/interactionControllers.js";
import { addTaskToProject } from "./controllers/taskControllers.js";
import { projectFieldsValidated } from "./validators/projectFormValidator.js";
import { taskFieldsValidated } from "./validators/taskFormValidator.js";
import { interactionFieldsValidated } from "./validators/interactionFormValidator.js";
import { handleForm } from "./utils/formUtils.js";
import { errorMessages, successMessages, showErrorAlert } from "./utils/alertUtils.js";
import { classLoadIcons } from "./utils/loadingUtils.js";




document.addEventListener('DOMContentLoaded', async () =>{
    await loadProjects();
    await initializeAllSelectors();
    
    
    document.querySelector('.add-project').addEventListener('click', openModalAddProject);
    document.querySelector('.close').addEventListener('click', closeModalAddProject);

 

    document.getElementById('dataProject').addEventListener('submit', function(event){ 
        event.preventDefault();
        
       

        if(projectFieldsValidated.projectName && projectFieldsValidated.startDate && projectFieldsValidated.endDate && projectFieldsValidated.client && projectFieldsValidated.campaignType){
            handleForm(addProject, closeModalAddProject, classLoadIcons.project);
        } else {
            showErrorAlert(errorMessages.field);
        }      
            
          
    });

    document.getElementById('overlay').addEventListener('click', function() {
        closeModalAddProject(); // Cierra la ventana de agregar proyecto
        closeModalProject();    // Cierra la ventana de detalles de proyecto
    });

    document.getElementById('mid-overlay').addEventListener('click', function() {
        closeModalAddInteraction();
        closeModalAddTask();
    })

    document.querySelector('.close-details-modal').addEventListener('click', closeModalProject);
    document.quer
    
    document.querySelector('.add-task').addEventListener('click', openCreateTaskModal);
    document.querySelector('.close-add-task-modal').addEventListener('click', closeModalAddTask);
 

    document.querySelector('.add-interaction').addEventListener('click', openModalAddInteraction);
    document.querySelector('.close-add-interaction-modal').addEventListener('click', closeModalAddInteraction);

    document.getElementById('dataTask').addEventListener('submit', function(event){
        event.preventDefault();
        if(taskFieldsValidated.taskName && taskFieldsValidated.dueDate && taskFieldsValidated.user && taskFieldsValidated.status){
            const projectId = document.querySelector('.add-task').getAttribute('data-project-id');
            
            handleForm(() => addTaskToProject(projectId), closeModalAddTask, classLoadIcons.task);
        } else {
            showErrorAlert(errorMessages.field);
        }      
        
    });

    document.getElementById('dataInteraction').addEventListener('submit', function(event){
        event.preventDefault();
        if(interactionFieldsValidated.interactionNotes && interactionFieldsValidated.date && interactionFieldsValidated.type){
            const projectId = document.querySelector('.add-interaction').getAttribute('data-project-id');
            
            handleForm(() => addInteractionToProject(projectId), closeModalAddInteraction, classLoadIcons.interaction);
        } else {
            showErrorAlert(errorMessages.field);
        }
        
    });
    
   

    });













