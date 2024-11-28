import { updateTask } from "../services/projectService.js";
import { addTask } from "../services/projectService.js";
import { reloadTaskTable } from "../view/taskView.js";
import { closeModalAddTask } from "../components/taskModal.js";
import { successMessages, errorMessages } from "../utils/alertUtils.js";

export async function addTaskToProject(projectId){   

    const taskId = document.getElementById('data-task-id').value;
    const taskData = {
        name: document.getElementById('create-task-name').value.trim(),
        dueDate: document.getElementById('create-task-due-date').value,
        assignedTo: document.getElementById('create-task-user').value,
        status: document.getElementById('create-task-status').value
    };


    try{
        if(taskId){
            await updateTask(taskId, taskData);
            reloadTaskTable(projectId);
            return successMessages.editTask;
        } else {
            await addTask(projectId, taskData);
            reloadTaskTable(projectId);
            return successMessages.task;           
        }
    }catch (error) {
        throw error;
    }


}