import { GET_CLIENTS } from "../constants/endpoints.js";

export const fetchClients = async() =>{
    try{
        const response = await fetch(GET_CLIENTS);
        if(!response.ok){
            throw new Error('Error al obtener los clientes');
        }

        const clients = await response.json();
        clients.sort((a, b) => a.name.localeCompare(b.name));
        return clients;
       
    } catch(error){
        console.error('Error al obtener los clientes', error);
        return [];
    }
}