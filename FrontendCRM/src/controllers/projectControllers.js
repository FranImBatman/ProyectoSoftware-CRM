
import { createProject, fetchProjects  } from "../services/projectService.js";
import { displayProjects } from "../view/projectView.js";
import { successMessages, errorMessages } from "../utils/alertUtils.js";


export async function addProject(){
    const projectData = {
        name: document.getElementById('create-project-name').value.trim(),
        startDate: document.getElementById('create-project-start-date').value,
        endDate: document.getElementById('create-project-end-date').value,
        client: document.getElementById('create-project-client-select').value,
        campaignType: document.getElementById('create-project-campaign-select').value
    };   

    try{    
        await createProject(projectData);
        return successMessages.project      
    }catch (error) {        
        throw error;       
    }

}



export async function loadProjects(){
    const projectsData = await fetchProjects();
    displayProjects(projectsData);
    setFilters(projectsData);
}

function setFilters(projects){
    document.getElementById('search-input').addEventListener('input', () => filterProjects(projects))
    document.getElementById('filter-campaign-type-select').addEventListener('change', () => filterProjects(projects))
    document.getElementById('filter-client-select').addEventListener('change', () => filterProjects(projects))
}

function filterProjects(projects){
    
    const query = document.getElementById('search-input').value.toLowerCase();
    const selectedCampaignType = document.getElementById('filter-campaign-type-select').value;
    const selectedClient = document.getElementById('filter-client-select').value;

    const filteredProjects = projects.filter(project =>{
        const matchesName = project.name.toLowerCase().includes(query);
        const matchesCampaignType = selectedCampaignType ? project.campaignType.id == selectedCampaignType : true;
        const matchesClient = selectedClient ? project.client.id == selectedClient : true;
        return matchesName && matchesCampaignType && matchesClient;
    });
    displayProjects(filteredProjects);
}