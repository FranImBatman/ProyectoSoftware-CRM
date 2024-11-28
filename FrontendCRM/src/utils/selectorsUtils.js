import { fetchClients } from "../services/clientService.js";
import { fetchCampaignTypes } from "../services/campaignTypesService.js";
import { fetchUsers } from "../services/userService.js";
import { fetchTaskStatus } from "../services/taskStatusService.js";
import { fetchInteractionTypes } from "../services/interactionTypeService.js";

async function loadSelectOptions(selectedElement, list){   
    const element = document.getElementById(selectedElement);
      
    list.forEach(e => {
        const option = document.createElement('option');
        option.value = e.id;
        option.textContent = e.name;
        element.appendChild(option);
    });
}

async function initializeClientSelectors(){
    const clients = await fetchClients();
    
    loadSelectOptions('filter-client-select', clients);
    loadSelectOptions('create-project-client-select', clients);
}

async function initializeCampaignTypesSelectors(){
    const campaignTypes = await fetchCampaignTypes();
    
    loadSelectOptions('filter-campaign-type-select', campaignTypes);
    loadSelectOptions('create-project-campaign-select', campaignTypes);
}

async function initializeUserSelectors(){
    const users = await fetchUsers();

    loadSelectOptions('create-task-user', users);   
}

async function initializeTaskStatusSelectors(){
    const taskStatus = await fetchTaskStatus();

    loadSelectOptions('create-task-status', taskStatus);
}

async function initializeInteractionTypesSelectors(){
    const interactionTypes = await fetchInteractionTypes();
    
    loadSelectOptions('create-interaction-type', interactionTypes);
}

export async function initializeAllSelectors() {
    initializeClientSelectors();
    initializeCampaignTypesSelectors();
    initializeInteractionTypesSelectors();
    initializeTaskStatusSelectors();
    initializeUserSelectors();
}