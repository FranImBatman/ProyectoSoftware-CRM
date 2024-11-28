import { fetchProjectById } from "../services/projectService.js";

export async function reloadInteractionTable(projectId){
    const projectDetails = await fetchProjectById(projectId);

    const interactionList = document.querySelector('#interactionTableBody tbody');
    interactionList.innerHTML = "";

    if (projectDetails.interactions && projectDetails.interactions.length > 0) {
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
        interactionList.innerHTML = '<tr><td colspan="4">No hay interacciones asociadas a este proyecto.</td></tr>';
    }
}