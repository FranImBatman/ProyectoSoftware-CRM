import { GET_CAMPAIGN_TYPES } from "../constants/endpoints.js";

export const fetchCampaignTypes = async() => {
    try{
        const response = await fetch(GET_CAMPAIGN_TYPES);       
        if(!response.ok){
            throw new Error('Error al obtener los tipos de campaña');
        }
        const campaignTypes = await response.json();
        
        return campaignTypes;
       
    } catch(error){
        console.error('Error al obtener los tipos de campaña', error);
        return [];
    }
}