import axios from "axios";

export default axios.create({
    baseURL: 'https://bedarbiai-app-windows.azurewebsites.net/'
    //  baseURL: 'https://localhost:44349/'
});