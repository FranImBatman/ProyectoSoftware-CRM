import { addInteraction } from "../services/projectService.js";
import { reloadInteractionTable } from "../view/interactionView.js";
import { successMessages } from "../utils/alertUtils.js";

export async function addInteractionToProject(projectId){

    const interactionData = {
        notes: document.getElementById('create-interaction-notes').value.trim(),
        date: document.getElementById('create-interaction-date').value,
        interactionType: document.getElementById('create-interaction-type').value
    };

    try{
        await addInteraction(projectId, interactionData);
        reloadInteractionTable(projectId);
        return successMessages.interaction;
    }catch (error) {
        throw error;
    }


}