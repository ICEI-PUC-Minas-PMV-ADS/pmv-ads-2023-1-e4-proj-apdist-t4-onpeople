'use strict';
import axios from 'axios';

const api = axios.create({
    baseURL: "https://localhost:7282/api",
});

export default api