import { API_URL } from "./consts.js";

const GET_PROJECTS = API_URL + 'api/v1/Project';
const GET_PROJECTS_BY_ID = API_URL + 'api/v1/Project/*'
const GET_CLIENTS = API_URL + 'api/v1/Clients';
const GET_CAMPAIGN_TYPES = API_URL + 'api/v1/CampaignTypes';
const POST_PROJECTS = API_URL + 'api/v1/Project';
const GET_USERS = API_URL + 'api/v1/Users';
const GET_TASK_STATUS = API_URL +  'api/v1/TaskStatus';
const GET_INTERACTION_TYPES = API_URL + 'api/v1/InteractionTypes';
const POST_TASKS = API_URL + 'api/v1/Project/{id}/tasks';
const POST_INTERACTIONS = API_URL + 'api/v1/Project/{id}/interactions';
const PUT_TASK = API_URL + 'api/v1/Tasks/{id}';

export { GET_CLIENTS, GET_CAMPAIGN_TYPES, GET_PROJECTS, POST_PROJECTS, GET_PROJECTS_BY_ID, GET_INTERACTION_TYPES, GET_USERS, GET_TASK_STATUS, POST_TASKS, POST_INTERACTIONS, PUT_TASK };